using DMTestWebAuto.Compilador.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMTestWebAuto.Compilador.AnalisadorSintatico
{
    public class RegraComandoValido : IRegraAnalisadorSintaticoComando
    {
        public string Mensagem { get; private set; }

        public bool Valide(string comando)
        {
            if (!Tokenizar.ValideFinalParametro(comando))
                Mensagem = $"O comando {comando.ToUpper()} não foi finalizado corretamente. Após o ')' deve ser '.' ou ']' ";

            if (!Tokenizar.ValideParametroDoComando(comando))
                Mensagem = $"O comando {comando.ToUpper()} possui uma definição de parametro inconsistente";
           
            return string.IsNullOrEmpty(Mensagem);
        }
    }
}
