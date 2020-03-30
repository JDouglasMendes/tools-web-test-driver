using DMTestWebAuto.WebDriver.Seletores;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMTestWebAuto.WebDriver.Comandos
{
    public class Comando
    {        
        public string Parametro { get; private set; }
        public ISeletor Seletor { get; private set; }    
        public Comando AdicioneParamentro(string parametro)
        {
            Parametro = parametro;
            return this;
        }
        public Comando AdicioneSeletor(ISeletor seletor)
        {
            Seletor = seletor;
            return this;
        }
    }
}
