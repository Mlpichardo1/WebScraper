using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebScraperApp.Models;
using WebScraperApp.Services;

namespace WebScraperApp.Controllers
{
    [Authorize]
    public class StockController : Controller
    {
        private readonly IStockItemService _stockItemService;
        private readonly UserManager<IdentityUser> _userManager;
            public StockController(IStockItemService stockItemService, 
            UserManager<IdentityUser> userManager)
            {
                _stockItemService = stockItemService;
                _userManager = userManager;
            }
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            var items = await _stockItemService
            .GetIncompleteItemsAsync(currentUser);
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
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

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
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            var successful = await _stockItemService.MarkDoneAsync(id);
            if (!successful)
            {
                return BadRequest("Could not mark item as done.");
            }
            return RedirectToAction("Index");
        }
    }
}