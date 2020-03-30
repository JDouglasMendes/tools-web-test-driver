using System;
using System.Collections.Generic;
using System.Text;

namespace DMTestWebAuto.WebDriver.Seletores
{
    public class ParametroSeletor
    {
        public string Identificador { get; private set; }
        public ParametroSeletor AdicioneIdentificador(string identificador)
        {
            Identificador = identificador;
            return this;
        }
    }
}
