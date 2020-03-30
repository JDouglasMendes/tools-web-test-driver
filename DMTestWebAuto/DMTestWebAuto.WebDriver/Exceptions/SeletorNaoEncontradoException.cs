using System;
using System.Collections.Generic;
using System.Text;

namespace DMTestWebAuto.WebDriver.Exceptions
{
    public class SeletorNaoEncontradoException : Exception
    {
        public SeletorNaoEncontradoException(string mensagem) : base(mensagem)
        {
        }
    }
}
