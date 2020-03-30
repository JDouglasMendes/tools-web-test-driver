using DMTestWebAuto.WebDriver.Exceptions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMTestWebAuto.WebDriver.Seletores
{
    public class ClasseSeletor : ISeletor
    {
        private IWebDriver _driver;
        private string _identificador;
        public ClasseSeletor(IWebDriver driver, string identificador)
        {
            _driver = driver;
            _identificador = identificador;
        }
        
        public IWebElement Seletor()
        {
            try
            {
                return _driver.FindElement(By.ClassName(_identificador));            }
            catch (NoSuchElementException)
            {
                throw new SeletorNaoEncontradoException(string.Format("Não existe classe CSS de nome {0} na URL {1}", _identificador, _driver.Url));
            }
        }
    }
}
