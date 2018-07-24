using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebScraperApp.Controllers;
using WebScraperApp.Models;

namespace WebScraperApp.Services
{
    public interface IStockItemService
    {
        Task<StockItem[]> GetIncompleteItemsAsync();
        Task<bool> AddItemAsync(StockItem newItem);
        Task<bool> MarkDoneAsync(Guid id);
    }
}