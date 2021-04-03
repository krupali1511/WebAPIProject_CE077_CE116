﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GrowTogether.Models;
using GrowTogether.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace GrowTogether.Controllers
{
    [Route("[controller]")]
  //  [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IFileService _fileService;
        public FileUploadController(IFileService fileService)
        {
            _fileService = fileService;
        }

        // download file(s) to client according path: rootDirectory/subDirectory with single zip file

        // upload file(s) to server that palce under path: rootDirectory/subDirectory
        [HttpPost("upload")]
        public IActionResult UploadFile([FromBody]Material material)
        {
            try
            {
                Console.WriteLine();
                _fileService.SaveFile(material);

                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest($"Error: {exception.Message}");
            }
        }
        [HttpGet("Materials")]
        public IEnumerable<Material> Get()
        {
            var files = _fileService.Getall();
            return files;
        }
    }
}

