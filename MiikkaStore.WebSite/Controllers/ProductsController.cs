using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiikkaStore.WebSite.Models;
using MiikkaStore.WebSite.Services;

namespace MiikkaStore.WebSite.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private MiikkaFileService _miikkaFileService;

        public ProductsController(MiikkaFileService miikkaFileService)
        {
            _miikkaFileService = miikkaFileService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _miikkaFileService.GetProducts();
        }
    }
}
