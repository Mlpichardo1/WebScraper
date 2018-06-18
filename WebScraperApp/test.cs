using System;

namespace WebScraperApp
{
    public class test
    {
        public void Initialize()
        {
            driver.Navigate().GoToUrl("http://executeautomation.com/demosite/index.html?UserName=&Password=&Login=Login");
            System.Console.WriteLine("Opened URL");
        }

        [Test]
        {
            public void ExecuteTest()
            // Title
            {
                SeleniumMethods.SelectDropDown(driver, "TitleId", "Mr.", "Id");
            // Initial
                SeleniumMethods.EnterText(driver, "Initial", "executeautomation", "Name");
            // Click Operation
            
            }
        }
    }
}