using GrowTogether.Models;
using GrowTogether.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace GrowTogether.Controllers
{

    public class FileService : IFileService
    {
        GrowDbContext _context = null;
        public FileService(GrowDbContext context)
        {
            _context = context;
        }

       
        public IEnumerable<Material> Getall()
        {
            try
            {
                var records = _context.Material;
                return records;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SaveFile(Material material)
        {
           
            try
            {
                var mat = new Material
                {
                    Name= material.Name,
                    Path = material.Path
                };
                _context.Material.Add(mat);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
}
