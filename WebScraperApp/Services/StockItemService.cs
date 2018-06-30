using System;
using System.Linq;
using System.Threading.Tasks;
using WebScraperApp.Data;
using WebScraperApp.Models;
using Microsoft.EntityFrameworkCore;

namespace WebScraperApp.Services
{
    public class StockItemService : IStockItemService
    {
        private readonly ApplicationDbContext _context;
        public StockItemService(ApplicationDbContext context)
        {
            _context = context;
        }   
        public async Task<StockItem[]> GetIncompleteItemsAsync()
        {
            return await _context.Items
                .Where(x => x.IsDone == false)
                .ToArrayAsync();
        }
        public async Task<bool> AddItemAsync(StockItem newItem)
        {
            newItem.Id = Guid.NewGuid();
            newItem.IsDone = false;
            newItem.DueAt = DateTimeOffset.Now.AddDays(3);
            _context.Items.Add(newItem);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}