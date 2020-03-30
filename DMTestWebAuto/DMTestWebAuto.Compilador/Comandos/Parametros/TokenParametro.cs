using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMTestWebAuto.Compilador.Comandos
{
    public class TokenParametro
    {
        private List<ParametroComando> ParametroComandos { get; set; }
        public TokenParametro(List<ParametroComando> parametroComandos) => ParametroComandos = parametroComandos;
       
        public ParametroComando this[string nome]
        {
            get
            {
                return ParametroComandos.FirstOrDefault(x =>
                {
                    if (string.IsNullOrEmpty(x.NomeCompleto))
                        x.NomeCompleto = string.Empty;
                    if (string.IsNullOrEmpty(x.NomeAbreviado))
                        x.NomeAbreviado = string.Empty;

                    return x.NomeAbreviado.ToLower() == nome.ToLower() ||
                       x.NomeCompleto.ToLower() == nome.ToLower();
                });
            }
        }
    }
}
