using DMTestWebAuto.Compilador.Comandos;
using DMTestWebAuto.Compilador.Compiladores;
using DMTestWebAuto.WebDriver.Drivers;
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
            using var driver = FabricaDriver.Crie(Browser.Chrome, PathDriver.Get);
            var comando = new AcesseComando();
            comando.SetContext(driver);
            comando.Execute(new List<ParametroComando>
            {
                new ParametroComando { Valor = url,
               NomeAbreviado = "-u"}
            });
            Assert.Contains("https://", driver.Url); 
        }

        [Theory]
        [InlineData("acesse -u http://www.google.com", "Acessando:")]
        public void ComandoCompletoSucessoCLI(string linha, string assert)
        {
            using var compilador = new CompiladorCLI(PathDriver.Get);
            var resultado = compilador.ExecuteComando(linha);
            Assert.Contains(assert, resultado);
        }
    }
}
