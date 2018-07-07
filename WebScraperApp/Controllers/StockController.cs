using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebScraperApp.Models;
using WebScraperApp.Services;

namespace WebScraperApp.Controllers
{
    [Authorize]
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(StockItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var successful = await _stockItemService.AddItemAsync(newItem);
            if (!successful)
            {
                return BadRequest("Could not add item.");
            }
            return RedirectToAction("Index");
        }
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }
            var successful = await _stockItemService.MarkDoneAsync(id);
            if (!successful)
            {
                return BadRequest("Could not mark item as done.");
            }
            return RedirectToAction("Index");
        }
    }
}