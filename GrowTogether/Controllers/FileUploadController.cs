﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GrowTogether.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using static GrowTogether.Models.Material;

namespace GrowTogether.Controllers
{
    [Route("api/[controller]")]
  //  [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly FileService _fileService;
        public FileUploadController()
        {

        }

        // download file(s) to client according path: rootDirectory/subDirectory with single zip file
        [HttpGet("Download/{subDirectory}")]
        public IActionResult DownloadFiles(string subDirectory)
        {
            try
            {
                var (fileType, archiveData, archiveName) = _fileService.FetechFiles(subDirectory);

                return File(archiveData, fileType, archiveName);
            }
            catch (Exception exception)
            {
                return BadRequest($"Error: {exception.Message}");
            }
        }

        // upload file(s) to server that palce under path: rootDirectory/subDirectory
        [HttpPost("upload")]
        public IActionResult UploadFile([FromForm(Name = "files")] List<IFormFile> files, string subDirectory)
        {
            try
            {
                _fileService.SaveFile(files, subDirectory);

                return Ok(new { files.Count, Size = FileService.SizeConverter(files.Sum(f => f.Length)) });
            }
            catch (Exception exception)
            {
                return BadRequest($"Error: {exception.Message}");
            }
        }
    }
}

