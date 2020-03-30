using DMTestWebAuto.WebDriver.Comandos;
using DMTestWebAuto.WebDriver.Seletores;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMTestWebAuto.Compilador.Comandos
{
    [TokenComando("settexto")]
    public class SetTextoComando : BaseComando, IComando
    {
        private IWebDriver _webDriver;
        public void SetContext(IWebDriver webDriver) => _webDriver = webDriver;

        public string Execute(List<ParametroComando> parametros)
        {
            var token = new TokenParametro(parametros);        
            var elemento = new ElementoPorSeletor(_webDriver).GetElemento(token["-e"].Valor);
            new SetTextoComandoDriver().Execute(elemento.Seletor(), token["-t"].Valor);
            return string.Empty;
        }

        public List<ParametroComando> GetParamentros(string linhaDoComando)
        {
            return BaseGetParametros(linhaDoComando);
        }

        protected override List<ParametroComando> GetParametrosValidos()
        {
            return new List<ParametroComando>
            {
                new ParametroComando
                {
                    NomeAbreviado = "-e",
                    NomeCompleto = "-elemento"
                },
                new ParametroComando
                {
                    NomeAbreviado = "-t",
                    NomeCompleto = "-texto"
                },

            };
        }
    }
}
