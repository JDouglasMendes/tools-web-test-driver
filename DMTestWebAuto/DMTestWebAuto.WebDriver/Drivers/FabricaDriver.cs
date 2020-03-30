using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMTestWebAuto.WebDriver.Drivers
{
    public static class FabricaDriver
    {        
        public static IWebDriver Crie(Browser browser, string caminhoDriver)
        {
            return  WebDriverFactory.CreateWebDriver(browser, caminhoDriver);            
        }
    }
}
