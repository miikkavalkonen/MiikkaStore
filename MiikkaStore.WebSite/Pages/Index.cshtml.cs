using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MiikkaStore.WebSite.Models;
using MiikkaStore.WebSite.Services;

namespace MiikkaStore.WebSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MiikkaFileService _miikkaFileService;

        public IEnumerable<Product> Products { get; set; }

        public IndexModel(ILogger<IndexModel> logger, MiikkaFileService miikkaFileService)
        {
            _logger = logger;
            _miikkaFileService = miikkaFileService;
        }

        public void OnGet()
        {
            // Alusta tuotteet modeliin ja looppaa hötömölön puolella
            try
            {
                Products = _miikkaFileService.GetProducts();
            }
            catch (Exception e)
            {
                _logger.LogError("Failed to initialize products", e);
            }
        }
    }
}
