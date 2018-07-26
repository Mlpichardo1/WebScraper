using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebScraperApp.Data;


namespace WebScraperApp
{
    public partial class Login
    {
        public static void Run(string[] args)
        {
            System.Console.WriteLine("Button Clicked");
            // Initialize the Chrome Driver
            using (var driver = new ChromeDriver())
            {
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

//         //      //Gets table body to 'myTable' instance
//         //     IWebElement myTable = driver.FindElement(By.XPath(""));
            
//         //      //Getting Number of rows in table
//         //     IList<IWebElement> rows = new List<IWebElement>(myTable.FindElements(By.TagName("tr")));
            
//         //     foreach (var colElement in rows)
//         //     {
//         //         //Getting Number of cols in row table
//         //         IList<IWebElement> cols = new List<IWebElement>(colElement.FindElements(By.TagName("td")));

//         //         if (cols.Count > 0) 
//         //         {
//         //             //Iterating through each cell

//         //             foreach (var cellData in cols)
//         //             {
//         //                 //getting each cell data
//         //                 String data = cellData.Text;
//         //                 Console.WriteLine("Data matched" + data);
//         //             }
                }
            }
        }
//                 // Take a screenshot and save it into screen.png
//                 // driver.GetScreenshot().SaveAsFile(@"screen.png", ScreenshotImageFormat.Png);
}

