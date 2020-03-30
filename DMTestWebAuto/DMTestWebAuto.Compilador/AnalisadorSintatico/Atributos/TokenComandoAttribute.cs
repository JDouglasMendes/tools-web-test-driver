using System;

namespace DMTestWebAuto.Compilador.Comandos
{
    internal class TokenComandoAttribute : Attribute
    {
        public string DescricaoComando { get; set; }

        public TokenComandoAttribute(string comando) => DescricaoComando = comando;
    }
}