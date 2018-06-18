using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebScraperApp
{
    public class SeleniumMethods
    {
        // Enter Text
        public static void EnterText(IWebDriver driver, string element, string value, string elementType)
        {
            if (elementType == "Id")
            driver.FindElement(By.Id(element)).SendKeys(value);
            if (elementType == "Name")
            driver.FindElement(By.Name(element)).SendKeys(value);
        }
        // Click operation for Button, checkbox etc
        public static void Click(IWebDriver driver, string element, string value, string elementType)
        {
            if (elementType == "Id")
            driver.FindElement(By.Id(element)).Click();
            if (elementType == "Name")
            driver.FindElement(By.Name(element)).Click();

        }
        // Selecting a Dropdown
        public static void SelectDropDown(IWebDriver driver, string element, string value, string elementType)
        {
            if (elementType == "Id")
            new SelectElement(driver.FindElement(By.Id(element))).SelectByText(value);
            if (elementType == "Name")
            new SelectElement(driver.FindElement(By.Name(element))).SelectByText(value);
        }
    }
}