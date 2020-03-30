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
    public class AguardeComandoTest
    {
        [Theory]
        [InlineData(10)]
        public void GetTextoComandoClasseSucesso(int tempo)
        {            
            new AguardeComando().Execute(new List<ParametroComando>
            {
                new ParametroComando{  NomeAbreviado = "-t", Valor = tempo.ToString() }
            });            
        }

        [Fact]
        public void ComandoCompletoSucessoCLI()
        {
            using var driver = Substitute.For<IWebDriver, IDisposable>();
            driver.Url = "http://www.google.com";
            driver.LoadPage(TimeSpan.FromSeconds(2000), "http://www.google.com");
            using var compilador = new CompiladorCLI(driver);
            var teste = compilador.ExecuteComando("acesse -u http://www.google.com");
            var retorno = compilador.ExecuteComando("aguarde -t 10");
            Assert.Contains("Aguardou", retorno);
            
        }
    }
}
