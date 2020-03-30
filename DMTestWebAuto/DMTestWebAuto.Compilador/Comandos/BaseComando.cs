using DMTestWebAuto.Compilador.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMTestWebAuto.Compilador.Comandos
{
    public abstract class BaseComando
    {
        protected List<ParametroComando> BaseGetParametros(string linhaDoComando)
        {
            try
            {
                var tokens = linhaDoComando.Split(" ").ToList();
                var tokensparamentros = tokens.GetRange(1, tokens.Count - 1);
                var parametrosUtilizados = new List<ParametroComando>();
                var parametrosPossivel = GetParametrosValidos();
                var index = 0;
                while (index < tokensparamentros.Count)
                {
                    var chave = tokensparamentros[index].ToLower();
                    var valor = tokensparamentros[index + 1];

                    if (string.IsNullOrEmpty(valor))
                        throw new AnalisadorSintaticoException($"Não foi informado valor para o parâmetro {chave}");

                    var p = parametrosPossivel.FirstOrDefault(x => x.NomeAbreviado == chave || x.NomeCompleto == chave);
                    if (p != null)
                    {
                        p.Valor = valor;
                        parametrosUtilizados.Add(p);
                    }
                    else
                    {
                        throw new AnalisadorSintaticoException($"O parâmetro {chave} não é conhecido para o comando");
                    }
                    index += 2;
                }

                return parametrosUtilizados;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected abstract List<ParametroComando> GetParametrosValidos();
        
    }
}
