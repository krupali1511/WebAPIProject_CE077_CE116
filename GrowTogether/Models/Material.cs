﻿using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GrowTogether.Models
{
    public class Material
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public class FilesViewModel
        {
            public List<Material> Files { get; set; }
                = new List<Material>();
        }

    }
}