using DMTestWebAuto.WebDriver.Comandos;
using DMTestWebAuto.WebDriver.Seletores;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMTestWebAuto.Compilador.Comandos
{
    [TokenComando("gettexto")]
    public class GetTextoComando : BaseComando, IComando
    {
        private IWebDriver _webDriver;
        public void SetContext(IWebDriver webDriver) => _webDriver = webDriver;

        public string Execute(List<ParametroComando> parametros)
        {
            var token = new TokenParametro(parametros);
            var elemento = new ElementoPorSeletor(_webDriver).GetElemento(token["-e"].Valor);
            return new GetComandoDriver().Execute(elemento.Seletor(), token["-a"]?.Valor);
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
                }
            };
        }
    }
}
