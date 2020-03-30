using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMTestWebAuto.WebDriver.Seletores
{
    public class ElementoPorSeletor
    {
        private IWebDriver _webDriver;
        public ElementoPorSeletor(IWebDriver webDriver) => _webDriver = webDriver;
        
        public ISeletor GetElemento(string identificador)
        {
            if (identificador.StartsWith("."))
                return new ClasseSeletor(_webDriver, sanitize(identificador));

            if (identificador.StartsWith("#"))
                return new IDSeletor(_webDriver, sanitize(identificador));

            throw new ArgumentException($"O idenficador {identificador} é invalido");
        }

        private string sanitize(string seletor)
        {
            return seletor.Replace("#", string.Empty).Replace(".", string.Empty);
        }
    }
}
