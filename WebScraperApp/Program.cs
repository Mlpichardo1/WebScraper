using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebScraperApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            // Reference for Browser
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://login.yahoo.com/?authMechanism=primary&done=https%3A%2F%2Fwww.yahoo.com%2F&eid=100&add=1");

            // Find Element
            IWebElement element = driver.FindElement(By.Name("q"));

            //Perform Ops
            element.SendKeys("");

            driver.Close();
            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
