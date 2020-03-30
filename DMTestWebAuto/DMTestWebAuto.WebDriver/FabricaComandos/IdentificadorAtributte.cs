using System;
using System.Collections.Generic;
using System.Text;

namespace DMTestWebAuto.WebDriver.FabricaComandos
{
    public class IdentificadorAtributte : Attribute
    {
        public EnumComandos Identificador { get; }
        public IdentificadorAtributte(EnumComandos identificador) => Identificador = identificador;       
    }
}
