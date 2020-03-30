using DMTestWebAuto.Compilador.AnalisadorSintatico;
using DMTools.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMTestWebAuto.Compilador.Tokens
{
    public class CompiladorArquivo
    {
        private string _conteudo;
        public CompiladorArquivo(string conteudo)
        {
            _conteudo = conteudo;
        }

        public bool Analise()
        {
            var linhas = GetLinhasUteis();
            var analisadoresGenerico = CarregueTodosAnalisadoreGenericos<IRegraAnalisadorSintaticoGenerico>();
            var resultadoCompilacao = AnaliseSintaticaGerais(linhas, analisadoresGenerico);
            if (resultadoCompilacao.ExisteErroCompilacao)
                throw resultadoCompilacao;

            var analisadoresComando = CarregueTodosAnalisadoreGenericos<IRegraAnalisadorSintaticoComando>();
            
            linhas.ForEach(x =>
            {
                analisadoresComando.ForEach(analisador =>
                {
                    if (!analisador.Valide(x))
                        resultadoCompilacao.AddErro(analisador.Mensagem);
                });
            });
            
            return true;
        }

        private static AnalisadorSintaticoException AnaliseSintaticaGerais(List<string> linhas, List<IRegraAnalisadorSintaticoGenerico> analisadores)
        {
            var resultadoCompilacao = new AnalisadorSintaticoException("Erro de compilação do cenário de teste");
            linhas.ForEach(linha =>
            {
                analisadores.ForEach(analisador =>
                {
                    if (!analisador.Valide(linha))
                        resultadoCompilacao.AddErro(analisador.Mensagem);
                });
            });
            return resultadoCompilacao;
        }

        private List<string> GetLinhasUteis()
        {
            return _conteudo.Split("\n").ToList().Where(x => !x.StartsWith(Constantes.Comentario)).ToList();
        }


        private List<IContratoAnalise> CarregueTodosAnalisadoreGenericos<IContratoAnalise>()
        {
            var analisadores = new List<IContratoAnalise>();

            var types = this.GetType().Assembly.GetTypes().Where(x => x.IsClass && x.GetInterface(nameof(IContratoAnalise), true) != null);

            types.ToList().ForEach(x =>
            {
                analisadores.Add((IContratoAnalise)Activator.CreateInstance(x));
            });

            return analisadores;
        }
    }
}
