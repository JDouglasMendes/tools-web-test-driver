using System;
using System.Collections.Generic;
using System.Text;

namespace DMTestWebAuto.Compilador.Utils
{
    public class ComandoNaoEncontradoException : Exception
    {
        public ComandoNaoEncontradoException(string mensagem) : base(mensagem)
        {
        }
    }
}
