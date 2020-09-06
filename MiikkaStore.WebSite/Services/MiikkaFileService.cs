using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MiikkaStore.WebSite.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MiikkaStore.WebSite.Services
{
    public class MiikkaFileService
    {
        private IWebHostEnvironment _webHostEnvironment;

        public MiikkaFileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        private string FileName
        {
            get { return Path.Combine(_webHostEnvironment.WebRootPath, "Data", "Products.json"); }
        }

        public IEnumerable<Product> GetProducts()
        {
            using var jsonFileReader = File.OpenText(FileName);
            return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                PropertyNameCaseInsensitive = true
                });
        }
    }
}
