using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebScraperApp.Models;

namespace WebScraperApp.Services
{
    public interface IStockItemService
    {
        Task<StockItem[]> GetIncompleteItemsAsync(IdentityUser user);
        Task<bool> AddItemAsync(StockItem newItem, IdentityUser user);
        Task<bool> MarkDoneAsync(Guid id, IdentityUser user);
    }
}