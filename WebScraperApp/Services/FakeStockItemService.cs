using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebScraperApp.Models;

namespace WebScraperApp.Services
{
    public interface FakeStockItemService
    {
         public Task<StockItem[]> GetIncompleteItemsAsync()
        {
            var item1 = new TodoItem
            {
                Title = "Learn ASP.NET Core",
                DueAt = DateTimeOffset.Now.AddDays(1)
            };
        var item2 = new TodoItem
            {
                Title = "Build awesome apps",
                DueAt = DateTimeOffset.Now.AddDays(2)
            };
            return Task.FromResult(new[] { item1, item2 });
        }
    }
}