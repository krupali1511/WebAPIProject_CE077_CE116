using GrowTogether.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrowTogether.Services
{
    public interface IFileService
    {
        public IEnumerable<Material> Getall();
        public void SaveFile(Material material);
        
    }
}
