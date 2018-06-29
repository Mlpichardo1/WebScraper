using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebScraperApp.Models;

namespace WebScraperApp.Services
{
    public interface StockItemService
    {
        Task<StockItem[]> GetIncompleteItemsAsync();
    }
}