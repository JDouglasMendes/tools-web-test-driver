using DMTestWebAuto.WebDriver.Seletores;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMTestWebAuto.WebDriver.Comandos
{
    public class ClickComandoDriver 
    {                
        public void Execute(IWebElement element)
        {
            element.Click();
        }
    }
}
