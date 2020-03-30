using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMTestWebAuto.WebDriver.Comandos
{
    public class GetComandoDriver
    {
        public string Execute(IWebElement element, string atributo = null)
        {
            if (!string.IsNullOrEmpty(atributo))
                return element.GetAttribute(atributo);

            return element.GetAttribute("value");
        }
    }
}
