using System;
using System.Linq;
using System.Threading.Tasks;
using WebScraperApp.Data;
using WebScraperApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WebScraperApp.Controllers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

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
            using (var driver = new FirefoxDriver())
            {
                System.Console.WriteLine("Selenium is running");
                // Go to the home page
                driver.Navigate().GoToUrl("https://login.yahoo.com/");

                // Get the page elements
                var userName = driver.FindElementById("login-username");
                var userLogin = driver.FindElementById("login-signin");
                var userPassword = driver.FindElementById("login-passwd");
                var userPort = driver.FindElementById("");
                
                // Type user name and password
                userName.SendKeys("mnl.pichardo@yahoo.com");
                userLogin.Click();
                userPassword.SendKeys("Milkman0");
                // Login 
                userLogin.Click();
                userPort.Click();

                System.Console.WriteLine("Selenium is running");
            }
            
            newItem.Id = Guid.NewGuid();
            newItem.IsDone = false;
            newItem.DueAt = DateTimeOffset.Now.AddDays(3);
            _context.Items.Add(newItem);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<bool> MarkDoneAsync(Guid id)
        {
            var item = await _context.Items
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (item == null) return false;
            
            item.IsDone = true;

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1; // One entity should have been updated
        }
    }
}