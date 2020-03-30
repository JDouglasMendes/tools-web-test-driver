using System;
using System.Collections.Generic;
using System.Text;

namespace DMTestWebAuto.Compilador.AnalisadorSintatico
{
    public interface IRegraAnalisadorSintaticoGenerico
    {
        bool Valide(string linha);
        string Mensagem { get; }
    }
}
