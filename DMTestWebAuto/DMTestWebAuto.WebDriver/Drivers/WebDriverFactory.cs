using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMTestWebAuto.WebDriver.Drivers
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(
            Browser browser, string pathDriver)
        {
            IWebDriver webDriver = null;

            switch (browser)
            {
                case Browser.Firefox:
                    FirefoxDriverService service =
                        FirefoxDriverService.CreateDefaultService(pathDriver);

                    webDriver = new FirefoxDriver(service);

                    break;
                case Browser.Chrome:
                    var service1 = ChromeDriverService.CreateDefaultService(pathDriver);
                    service1.HideCommandPromptWindow = true;                    
                    var options = new ChromeOptions();
                    options.AddArgument("disable-logging");
                    webDriver = new ChromeDriver(service1, options);                    
                    webDriver.Manage().Window.Maximize();  
                    break;
            }

            return webDriver;
        }
    }
}
