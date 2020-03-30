using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMTestWebAuto.WebDriver.Drivers
{
    public static class WebDriverExtensions
    {
        public static void LoadPage(this IWebDriver webDriver,
            TimeSpan timeToWait, string url)
        {
            webDriver.Manage().Timeouts().PageLoad = timeToWait;
            webDriver.Navigate().GoToUrl(url);
        }

        public static string GetText(this IWebDriver webDriver, By by)
        {
            IWebElement webElement = webDriver.FindElement(by);
            return webElement.Text;
        }

        public static void SetText(this IWebDriver webDriver,
            By by, string text)
        {
            IWebElement webElement = webDriver.FindElement(by);
            webElement.SendKeys(text);
        }

        public static void SetText(this IWebElement webElement,string text)
        {            
            webElement.SendKeys(text);
        }

        public static void Submit(this IWebDriver webDriver, By by)
        {
            IWebElement webElement = webDriver.FindElement(by);
            webElement.Submit();            
        }

        public static void Click(this IWebDriver webDriver, By by)
        {
            IWebElement webElement = webDriver.FindElement(by);
            webElement.Click();
        }

        public static IWebElement GetElementById(this IWebDriver webDriver, string id)
        {
            return webDriver.FindElement(By.Id(id));
        }
    }
}
