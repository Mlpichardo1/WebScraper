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
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Globalization;

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
        public async Task<List<StockItem>> GetStockSnapshotsAsync(string sortOrder)
        {

            IQueryable<StockItem> snapshot = from s in _context.Items
                                             select s;

            switch (sortOrder)
            {
                case "Date":
                    snapshot = snapshot.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    snapshot = snapshot.OrderByDescending(s => s.Date);
                    break;
                case "TotalValue":
                    snapshot = snapshot.OrderBy(s => s.TotalValue);
                    break;
                case "totalvalue_desc":
                    snapshot = snapshot.OrderByDescending(s => s.TotalValue);
                    break;
                case "DayGain":
                    snapshot = snapshot.OrderBy(s => s.DayGain);
                    break;
                case "daygain_desc":
                    snapshot = snapshot.OrderByDescending(s => s.DayGain);
                    break;
                case "DayGainPercent":
                    snapshot = snapshot.OrderBy(s => s.DayGainPercent);
                    break;
                case "daygainpercent_desc":
                    snapshot = snapshot.OrderByDescending(s => s.DayGainPercent);
                    break;
                case "TotalGain":
                    snapshot = snapshot.OrderBy(s => s.TotalGain);
                    break;
                case "totalgain_desc":
                    snapshot = snapshot.OrderByDescending(s => s.TotalGain);
                    break;
                case "TotalGainPercent":
                    snapshot = snapshot.OrderBy(s => s.TotalGainPercent);
                    break;
                case "totalgainpercent_desc":
                    snapshot = snapshot.OrderByDescending(s => s.TotalGainPercent);
                    break;
                default:
                    snapshot = snapshot.OrderBy(s => s.Date);
                    break;
            }

            return await snapshot
                        .Where(x=> x.UserId == user.Id)
                        .AsNoTracking().ToListAsync();
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
                IWebElement passwordWait = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.XPath("//*[@id='login-passwd']"));
            }); 

            driver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_0/view/v2");
            
            try
            {
                IWebElement popup = wait.Until<IWebElement>((d) =>
                {
                    return d.FindElement(By.XPath("//*[@id='fin-tradeit']/div[2]/div/div/div[2]/button[2]"));
                });

                driver.FindElement(By.XPath("//*[@id='fin-tradeit']/div[2]/div/div/div[2]/button[2]")).Click();
                System.Console.WriteLine("Popup clicked");
            }
            catch(WebDriverException e)
            {
                System.Console.WriteLine("Popup not found {0}", e);
            }

            var totalValue = driver.FindElement(By.ClassName("_3wreg")).Text;
            var dayGain = driver.FindElement(By.ClassName("_2ETlv")).FindElement(By.TagName("span")).Text.Split(" ");
            var totalGain = driver.FindElement(By.ClassName("_2HvXW")).FindElement(By.TagName("span")).Text.Split(" ");

            newItem.Date = DateTime.Now;
            newItem.TotalValue = double.Parse(totalValue, NumberStyles.Currency);
            newItem.TotalGain = double.Parse(totalGain[0]);     
            newItem.TotalGainPercent = double.Parse(totalGain[1].Trim( new char[] { '%', ' ', '(', ')' } ) ) / 100;
            newItem.DayGain = double.Parse(dayGain[0]);
            newItem.DayGainPercent = double.Parse(dayGain[1].Trim( new char[] { '%', ' ','(', ')' } ) ) / 100;        

            var portfolioStockList = new List<Stock>();
            
            IWebElement tableWait = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.ClassName("tJDbU"));
            });

            var stockListTable = driver.FindElement(By.ClassName("tJDbU"));
            var stockListTableRows = stockListTable.FindElements(By.ClassName("_14MJo"));
            var stockInfo = new List<string>();

            foreach (var row in stockListTableRows)
            {
                var stockListTableCells = row.FindElements(By.TagName("td"));
                if (stockListTableCells.Count > 0)
                {
                    foreach (var cell in stockListTableCells)
                    {
                        stockInfo.Add(cell.Text);
                    }

                    var stockSymbolAndPrice = stockInfo[0].ToString().Split("\n");
                    var changeByDollarAndPercent = stockInfo[1].ToString().Split("\n");
                    var dayGainByDollarAndPercent = stockInfo[5].ToString().Split("\n");
                    var totalGainByDollarAndPercent = stockInfo[6].ToString().Split("\n");
                    var lotSplit = stockInfo[7].Split(" ");
            
                    portfolioStockList.Add(new Stock()
                    {
                        StockSymbol = stockSymbolAndPrice[0].ToString(),          
                        CurrentPrice = double.Parse(stockSymbolAndPrice[1]),
                        ChangeByDollar = double.Parse(changeByDollarAndPercent[1]),
                        ChangeByPercent = (double.Parse(changeByDollarAndPercent[0].Trim( new char[] {'%' } )) / 100),
                        Shares = double.Parse(stockInfo[2]),  
                        CostBasis = double.Parse(stockInfo[3]),
                        MarketValue = double.Parse(stockInfo[4]),
                        DayGainByDollar = double.Parse(dayGainByDollarAndPercent[1]),
                        DayGainByPercent = (double.Parse(dayGainByDollarAndPercent[0].Trim( new char[] {'%' } )) / 100),
                        TotalGainByDollar = double.Parse(totalGainByDollarAndPercent[1]),
                        TotalGainByPercent = (double.Parse(totalGainByDollarAndPercent[0].Trim( new char[] {'%' } )) / 100),
                        Lots = double.Parse(lotSplit[0]),
                        Notes = stockInfo[8],
                    });
                }
                System.Console.WriteLine("Stock done");
                stockInfo.Clear();
            }

            System.Console.WriteLine("Driver quitting");
            driver.Quit();
            newSnapshot.Stocks = portfolioStockList;
            newSnapshot.UserId = user.Id;
            _context.Portfolios.Add(newSnapshot);

            var saveResult = await _context.SaveChangesAsync();

            if (saveResult > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            // if operation was successful, we will return true, because saveResult should == how many objects were saved to DB. If it is less than 0, we know it failed and return false
        
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