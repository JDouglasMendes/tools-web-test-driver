using DMTestWebAuto.WebDriver.Drivers;
using DMTestWebAuto.WebDriver.Exceptions;
using DMTestWebAuto.WebDriver.Verificacoes.Tokens;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMTestWebAuto.WebDriver.Verificacoes
{
    public class VerificaSeExiste : IVerificaSeExistePorID
    {
        private IWebDriver _driver;

        public VerificaSeExiste(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool Verifique(string id)
        {
            try
            {
                var element = _driver.GetElementById(id);
                return element != null;
            }
            catch(NoSuchElementException)
            {
                throw new SeletorNaoEncontradoException(string.Format("Não existe o id {0} na URL {1}", id, _driver.Url));
            }
        }
    }
}
