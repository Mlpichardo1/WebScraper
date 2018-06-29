using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebScraperApp.Models;
using WebScraperApp.Services;

namespace WebScraperApp.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockItemService _stockItemService;
            public StockController(IStockItemService stockItemService)
            {
                _stockItemService = stockItemService;
            }
        public async Task<IActionResult> Index()
        {
            var items = await _stockItemService.GetIncompleteItemsAsync();
            var model = new StockViewModel()
            {
                Items = items
            };
                return View(model);
            }
    }
}