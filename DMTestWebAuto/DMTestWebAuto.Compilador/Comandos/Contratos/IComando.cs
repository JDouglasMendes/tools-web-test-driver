using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMTestWebAuto.Compilador.Comandos
{
    public interface IComando
    {
        string Execute(List<ParametroComando> parametros);
        List<ParametroComando> GetParamentros(string linhaDoComando);
        void SetContext(IWebDriver webDriver);
    }
}
