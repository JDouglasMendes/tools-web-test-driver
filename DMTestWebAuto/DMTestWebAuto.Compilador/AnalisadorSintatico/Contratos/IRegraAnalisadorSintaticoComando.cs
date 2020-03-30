using System;
using System.Collections.Generic;
using System.Text;

namespace DMTestWebAuto.Compilador.AnalisadorSintatico
{
    public interface IRegraAnalisadorSintaticoComando
    {
        bool Valide(string linha);
        string Mensagem { get; }
    }
}
