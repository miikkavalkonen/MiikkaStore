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

        public IndexModel(ILogger<IndexModel> logger, MiikkaFileService miikkaFileService)
        {
            _logger = logger;
            _miikkaFileService = miikkaFileService;
        }

        public IActionResult OnPostPriceUpdate([FromBody] PriceUpdateDto priceUpdate)
        {
            try
            {
                _miikkaFileService.UpdateProduct(priceUpdate.ProductNumber - 1, priceUpdate.Price);
            }
            catch (Exception ex)
            {
                _logger.LogError("PriceUpdate error:", ex);
                return new BadRequestResult();
            }

            return new OkResult();
        }
    }

    public class PriceUpdateDto
    {
        public int ProductNumber { get; set; }
        public double Price { get; set; }
    }
}
