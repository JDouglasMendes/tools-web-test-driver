using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMTestWebAuto.WebDriver.Comandos
{
    public class SetTextoComandoDriver
    {        
        public void Execute(IWebElement element, string novoTexto)
        {
            element.SendKeys(novoTexto);
        }
    }
}
