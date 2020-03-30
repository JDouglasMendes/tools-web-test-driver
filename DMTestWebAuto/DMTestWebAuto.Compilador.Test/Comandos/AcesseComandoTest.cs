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
    public class AcesseComandoTest
    {
        [Theory]
        [InlineData("http://www.google.com")]
        public void AcesseComandoComSucesso(string url)
        {
            using var driver = Substitute.For<IWebDriver, IDisposable>();
            driver.Url = url;
            driver.LoadPage(TimeSpan.FromSeconds(2000), url);          
            var comando = new AcesseComando();
            comando.SetContext(driver);
            comando.Execute(new List<ParametroComando>
            {
                new ParametroComando { Valor = url,
               NomeAbreviado = "-u"}
            });
            Assert.Contains("http://", driver.Url); 
        }

        [Theory]
        [InlineData("acesse -u http://www.google.com", "Acessando:", "http://www.google.com")]
        public void ComandoCompletoSucessoCLI(string linha, string assert, string url)
        {
            using var driver = Substitute.For<IWebDriver, IDisposable>();
            driver.Url = url;
            driver.LoadPage(TimeSpan.FromSeconds(2000), url);
            using var compilador = new CompiladorCLI(driver);
            var resultado = compilador.ExecuteComando(linha);
            Assert.Contains(assert, resultado);
        }
    }
}
