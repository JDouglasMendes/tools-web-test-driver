using DMTestWebAuto.Compilador.Comandos;
using DMTestWebAuto.Compilador.Compiladores;
using DMTestWebAuto.WebDriver.Drivers;
using NSubstitute;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DMTestWebAuto.Compilador.Test.Comandos
{
    public class ClickComandoTest
    {
        [Theory]
        [InlineData("https://g1.globo.com/", ".barra-item-esportes")]
        public void GetTextoComandoClasseSucesso(string url, string selector)
        {
            using var driver = Substitute.For<IWebDriver, IDisposable>();            
            driver.Manage().Window.Maximize();
            driver.LoadPage(TimeSpan.FromSeconds(2000), url);
            driver.Url = "https://globoesporte.globo.com";
            var comando = new ClickComando();
            comando.SetContext(driver);
            comando.Execute(new List<ParametroComando>
            {
                new ParametroComando{  NomeAbreviado = "-e", Valor = selector }
            });            
            Assert.Contains("https://globoesporte.globo.com", driver.Url);            
        }

        [Theory]
        [InlineData("click -e .barra-item-esportes")]
        public void ComandoCompletoSucessoCLI(string linha)
        {
            using var driver = Substitute.For<IWebDriver, IDisposable>();
            using var compilador = new CompiladorCLI(driver);
            driver.Manage().Window.Maximize();
            driver.LoadPage(TimeSpan.FromSeconds(2000), "https://g1.globo.com/");
            var resultado = compilador.ExecuteComando("acesse -u https://g1.globo.com/");
            resultado = compilador.ExecuteComando(linha);
            Assert.Equal(string.Empty, resultado);
        }

        [Fact]
        public void TestLoginBJShared()
        {
            using var driver = Substitute.For<IWebDriver, IDisposable>();
            using var compilador = new CompiladorCLI(driver);
            compilador.ExecuteComando("acesse -u https://bj-share.info/login.php");
            compilador.ExecuteComando("settexto -e #username -t usuario");
            compilador.ExecuteComando("settexto -e #password -t senha");
            compilador.ExecuteComando("click -e .submit");
        }

    }
}
