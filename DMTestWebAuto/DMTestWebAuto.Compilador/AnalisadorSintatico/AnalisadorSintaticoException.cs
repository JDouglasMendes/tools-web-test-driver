using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMTestWebAuto.Compilador.Tokens
{
    public class AnalisadorSintaticoException : Exception
    {
        public AnalisadorSintaticoException(string mensagem) : base(mensagem)
        {
            Erros = new List<string>();
        }

        public List<String> Erros { get; private set; }
        public void AddErro(string mensagem)
        {
            Erros.Add(mensagem);
        }

        public bool ExisteErroCompilacao => Erros.Any();
    }
}
