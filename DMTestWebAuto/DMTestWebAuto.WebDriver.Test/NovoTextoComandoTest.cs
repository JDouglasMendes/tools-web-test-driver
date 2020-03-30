using DMTestWebAuto.WebDriver.Comandos;
using DMTestWebAuto.WebDriver.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DMTestWebAuto.WebDriver.Test
{
    public class NovoTextoComandoTest
    {
        [Theory]
        [InlineData("https://www.infoq.com/", "search", "valor")]
        public void NovoTextoPorClasse(string url, string classe, string valor)
        {
            using var driver = FabricaDriver.Crie(Browser.Chrome, PathDriver.Get);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(2000);          
            driver.Navigate().GoToUrl(url);
            System.Threading.Thread.Sleep(2000);
            var element = driver.FindElement(By.Id(classe));
            var novoTexto = new SetTextoComandoDriver();
            novoTexto.Execute(element, valor);            
        }
    }
}
