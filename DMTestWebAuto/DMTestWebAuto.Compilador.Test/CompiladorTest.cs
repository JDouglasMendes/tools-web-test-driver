using DMTestWebAuto.Compilador.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DMTestWebAuto.Compilador.Test
{
    public class CompiladorTest
    {
        [Theory]
        [InlineData("acesse -url \"www.google.com\"")]
        [InlineData("acesse -u \"www.google.com\"")]
        public void CompiladoComSucessoCenarioSimples(string comandoSimples)
        {
            var compilador = new Tokens.CompiladorArquivo(comandoSimples);
            Assert.True(compilador.Analise());
        }
    }
}
