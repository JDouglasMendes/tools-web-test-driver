using DMTestWebAuto.Compilador.Comandos;
using DMTestWebAuto.Compilador.Compiladores;
using DMTestWebAuto.WebDriver.Drivers;
using NSubstitute;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace DMTestWebAuto.Compilador.Test.Comandos
{
    public class SetTextoComandoTest
    {
        [Theory]
        [InlineData("https://bj-share.info/login.php", "#username", "usuarioTESTE")]
        public void SetTextoComandoIDSucesso(string url, string selector, string texto)
        {
            using var driver = Substitute.For<IWebDriver, IDisposable>();
            driver.LoadPage(TimeSpan.FromSeconds(2000), url);
            var comando = new SetTextoComando();
            comando.SetContext(driver);
            comando.Execute(new List<ParametroComando>
            {
                new ParametroComando{  NomeAbreviado = "-e", Valor = selector },
                new ParametroComando { NomeAbreviado =  "-t", Valor = texto }
            });
            var element = Substitute.For<IWebElement>();
            element.GetAttribute("value").Returns(texto);
            Assert.Equal(texto, element.GetAttribute("value"));
        }

        [Theory]
        [InlineData("settexto -e #username -t usuarioTESTE")]
        public void ComandoCompletoSucessoCLI(string linha)
        {
            using var driver = Substitute.For<IWebDriver, IDisposable>();
            using var compilador = new CompiladorCLI(driver);
            compilador.ExecuteComando($"acesse -u https://bj-share.info/login.php");
            var resultado = compilador.ExecuteComando(linha);           
            Assert.Equal(resultado, string.Empty);
        }


    }
}
