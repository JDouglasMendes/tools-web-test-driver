using DMTestWebAuto.WebDriver.Comandos;
using DMTestWebAuto.WebDriver.Drivers;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using OpenQA.Selenium;
using System;
using System.IO;
using Xunit;

namespace DMTestWebAuto.WebDriver.Test
{
    public class AcesseComandoTest
    {
        [Theory]
        [InlineData("http://www.google.com.br")]
        public void CarregaPaginaTest(string url)
        {
            using var driver = Substitute.For<IWebDriver, IDisposable>();
            var comando = new AcesseComandoDriver(driver);
            comando.Execute(new Comando().AdicioneParamentro(url));
            var element = driver.FindElement(By.ClassName("gb_g"));
            Assert.NotNull(element);
        }
    
    }
}
