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
    public class GetTextoComandoTest
    {
        [Theory]
        [InlineData("https://bj-share.info/login.php", ".submit", "Login")]
        public void GetTextoComandoClasseSucesso(string url, string selector, string texto)
        {
            using var driver = Substitute.For<IWebDriver, IDisposable>();
            driver.LoadPage(TimeSpan.FromSeconds(2000), url);
            var comando = new GetTextoComando();
            comando.SetContext(driver);
            comando.Execute(new List<ParametroComando>
            {
                new ParametroComando{  NomeAbreviado = "-e", Valor = selector }               
            });
            var element = Substitute.For<IWebElement>();
            element.GetAttribute("value").Returns(texto);
            Assert.Equal(texto, element.GetAttribute("value"));
        }

        [Theory]
        [InlineData("gettexto -e .submit")]
        public void ComandoCompletoSucessoCLI(string linha)
        {
            using var driver = Substitute.For<IWebDriver, IDisposable>();           
            using var compilador = new CompiladorCLI(driver);
            var resultado = compilador.ExecuteComando("acesse -u https://bj-share.info/login.php");
            resultado = compilador.ExecuteComando(linha);
            Assert.Equal(string.Empty, resultado);
        }
    }
}
