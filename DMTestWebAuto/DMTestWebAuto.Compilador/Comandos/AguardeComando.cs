using DMTestWebAuto.WebDriver.Comandos;
using DMTestWebAuto.WebDriver.Seletores;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMTestWebAuto.Compilador.Comandos
{
    [TokenComando("aguarde")]
    public class AguardeComando : BaseComando, IComando
    {
        public string Execute(List<ParametroComando> parametros)
        {
            var token = new TokenParametro(parametros);            
            new AguardeComandoDriver().Execute(int.Parse(token["-t"].Valor));
            return $"Aguardou {int.Parse(token["-t"].Valor)} segundos";
        }

        public List<ParametroComando> GetParamentros(string linhaDoComando)
        {
            return BaseGetParametros(linhaDoComando);
        }

        private IWebDriver _webDriver;
        public void SetContext(IWebDriver webDriver) => _webDriver = webDriver;

        protected override List<ParametroComando> GetParametrosValidos()
        {
            return new List<ParametroComando>
            {
                new ParametroComando
                {
                    NomeAbreviado = "-t",
                    NomeCompleto = "-tempo"
                }
            };
        }
    }
}
