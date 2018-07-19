using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebScraperApp.Models;

namespace WebScraperApp.Services
{
    public interface IStockItemService
    {
        Task<StockItem[]> GetIncompleteItemsAsync(ApplicationUser user);
        Task<bool> AddItemAsync(StockItem newItem, ApplicationUser user);
        Task<bool> MarkDoneAsync(Guid id, ApplicationUser user);
    }
}