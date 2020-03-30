using DMTestWebAuto.WebDriver.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMTestWebAuto.WebDriver.Comandos
{
    public class AcesseComandoDriver : IComando
    {
        private IWebDriver _driver;
        
        public AcesseComandoDriver(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Execute(Comando comando){

            _driver.LoadPage(TimeSpan.FromSeconds(2000), comando.Parametro);
        }
    }
}
