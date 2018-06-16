using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebScraperApp
{
    class Login
    {
        static void Main(string[] args)
        {
            //Create the reference for our browser
            IWebDriver driver = new ChromeDriver();
            
            //Navigate to google page
            driver.Navigate().GoToUrl("http:www.yahoo.com");
            
            //Find the Search text box UI Element
            IWebElement element = driver.FindElement(By.Name("q"));
            
            //Perform Ops
            element.SendKeys("executeautomation");
            
            //Close the browser
            // driver.Close();
        }
    }
}