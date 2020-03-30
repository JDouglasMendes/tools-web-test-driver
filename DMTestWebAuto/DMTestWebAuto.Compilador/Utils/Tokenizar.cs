using DMTestWebAuto.Compilador.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMTestWebAuto.Compilador.Utils
{
    public static class Tokenizar
    {
        public static EnumSeguroComandos IdentifiqueComando(string linha)
        {            
            EnumSeguroComandos retorno = null;            
            var comando = linha.Substring(0, linha.IndexOf(Constantes.Inicio_Parametros, StringComparison.OrdinalIgnoreCase));            
            retorno = EnumSeguroComandos.GetPorNome(comando);
            if (retorno == null)
                throw new ComandoNaoEncontradoException("Não foi possível encontrar comandos");

            return retorno;
        }
 
        /// <summary>
        /// Depois de um ) deve ser um "." ou "]"
        /// </summary>
        public static bool ValideFinalParametro(string linha)
        {
            const char ponto = '.';
            const char parentese = ')';
            var indice = 0;
            while (indice <= linha.Length)
            {
                var posicao = linha.IndexOf(Constantes.Fim_Parametros, indice);
                if (posicao + 1 >= linha.Length)
                    return indice == 0 ? false : true;

                if (posicao == -1)
                    return indice == linha.Length -1 ? true : false;

                if (!(linha.ElementAt(posicao).CompareTo(ponto) == 0 || linha.ElementAt(posicao).CompareTo(parentese) == 0))              
                    return false;
              
                indice = posicao + 1;
            }
            return true;
        }


        /// <summary>
        /// Deve haver pelo menos 1 "()"        
        /// </summary>                
        public static bool ValideParametroDoComando(string linha)
        {
            const char parenteseFinal = ')';
            const char parenteseInicial = '(';
            const char espaco = ' ';

            if (linha.Count(x => x.CompareTo(parenteseInicial) == 0) != 1)
                return false;

            if (linha.Count(x => x.CompareTo(parenteseFinal) == 0) != 1)
                return false;
            
            var posicaoInicio = linha.IndexOf(Constantes.Inicio_Parametros) + 1;
            var posicaoFinal = linha.IndexOf(Constantes.Fim_Parametros) - 1;

            if (posicaoInicio + 1 == posicaoFinal)
                return true;

            var parcial = linha.Substring(posicaoInicio);
            var parametro = string.Concat(parcial.Take(parcial.IndexOf(parenteseFinal)));

            if (parametro.Any(x => x.CompareTo(espaco) == 0))
                return false;

            return true;
        }

        public static List<string> GetComandos(string linha)
        {
            return linha.Split(Constantes.Separador_Comandos).ToList();
        }

        public static List<string> GetComandos(List<string> linhas)
        {
           
            return linhas.Select(LimpeLinha)
                .Aggregate<string, List<string>>(new List<string>(), (retorno, x) => {
                    retorno.AddRange(GetComandos(x));
                    return retorno;
                    });

        }

        private static string LimpeLinha(string linha)
        {
            return linha.Replace(Constantes.Inicio_comando, string.Empty).Replace(Constantes.Fim_comando, string.Empty);
        }

    }
}
