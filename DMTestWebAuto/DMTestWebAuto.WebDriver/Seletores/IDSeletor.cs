using DMTestWebAuto.WebDriver.Exceptions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMTestWebAuto.WebDriver.Seletores
{
    public class IDSeletor : ISeletor
    {
        private IWebDriver _driver;
        private string _id;
        public IDSeletor(IWebDriver driver, string id)
        {
            _driver = driver;
            _id = id;
        }

        public IWebElement Seletor()
        {
            try
            {
                return _driver.FindElement(By.Id(_id));
            }
            catch (NoSuchElementException)
            {
                throw new SeletorNaoEncontradoException(string.Format("Não existe ID com o nome {0} na URL {1}", _id, _driver.Url));
            }
        }
    }
}
