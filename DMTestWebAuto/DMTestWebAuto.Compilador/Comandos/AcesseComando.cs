﻿using DMTestWebAuto.Compilador.Tokens;
using DMTestWebAuto.WebDriver.Comandos;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMTestWebAuto.Compilador.Comandos
{
    [TokenComando("acesse")]
    public class AcesseComando : BaseComando , IComando
    {
        private IWebDriver _webDriver;

        public string Execute(List<ParametroComando> parametros)
        {
            var url = parametros.FirstOrDefault().Valor;
            if (!url.ToLower().StartsWith("http") && !url.ToLower().StartsWith("https"))
                url = "http://" + url;

            new AcesseComandoDriver(_webDriver).Execute(new Comando().AdicioneParamentro(url));
            return $"Acessando: {_webDriver.Url}";
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
                    NomeAbreviado = "-u",
                    NomeCompleto = "-url"
                }
            };
        }

        public void SetContext(IWebDriver webDriver) => _webDriver = webDriver;       
    }
}
