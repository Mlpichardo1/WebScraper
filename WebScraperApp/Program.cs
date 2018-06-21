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

            // Initialize the Chrome Driver
            using (var driver = new ChromeDriver())
            {
                // Go to the home page
                driver.Navigate().GoToUrl("https://login.yahoo.com/?authMechanism=primary&done=https%3A%2F%2Fwww.yahoo.com%2F&eid=100&add=1");

                // Get the page elements
                var userName = driver.FindElementById("login-username");
                var userLogin = driver.FindElementById("login-signin");
                // var notRobot = driver.FindElementByClassName("recaptcha-checkbox-checkmark");
                // var submit = driver.FindElementById("recaptcha-submit");
                var userPassword = driver.FindElementById("login-passwd");
                
                // Type user name and password
                userName.SendKeys("mnl.pichardo@yahoo.com");
                userLogin.Click();
                // notRobot.Click();
                // submit.Click();
                userPassword.SendKeys("Milkman0");
                // Login 
                userLogin.Click();

                driver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_1/view/v2");

                // Take a screenshot and save it into screen.png
                driver.GetScreenshot().SaveAsFile(@"screen.png", ScreenshotImageFormat.Png);
            }
            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

                
    }
}
