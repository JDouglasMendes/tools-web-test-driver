using DMTestWebAuto.Compilador.Comandos.Fabricas;
using DMTestWebAuto.WebDriver.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMTestWebAuto.Compilador.Compiladores
{
    public class CompiladorCLI : IDisposable
    {
        public IWebDriver WebDriver { get; }
        private List<string> _tokens;
        public CompiladorCLI(string pathDriver)
        {
            WebDriver = FabricaDriver.Crie(Browser.Chrome, pathDriver);
            _tokens = new List<string>();
            FabricaComando.Singleton.SetAllContext(WebDriver);
        }

        public string ExecuteComando(string linha)
        {
            linha = SanitizeLinha(linha);
            _tokens = GetTodosTokens(linha);
            var comando = FabricaComando.Singleton.Crie(_tokens.First());
            var paramentos = comando.GetParamentros(linha);
            return comando.Execute(paramentos);
        }

        private List<string> GetTodosTokens(string linha)
        {            
            return linha.Split(" ").ToList();
        }

        private static string SanitizeLinha(string linha)
        {
            while (linha.IndexOf("  ") > 0)
            {
                linha = linha.Replace("  ", " ");
            }

            return linha;
        }

        public void Dispose()
        {
            WebDriver.Dispose();
        }
    }
}
