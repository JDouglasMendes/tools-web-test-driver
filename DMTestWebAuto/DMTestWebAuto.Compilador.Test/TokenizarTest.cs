using DMTestWebAuto.Compilador.Tokens;
using DMTestWebAuto.Compilador.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DMTestWebAuto.Compilador.Test
{
    public class TokenizarTest
    {
        [Theory]
        [InlineData("ACESSE(gmail.com)")]
        public void IdentificaComando(string comando)
        {
            Assert.Equal<EnumSeguroComandos>(EnumSeguroComandos.Acesse, Tokenizar.IdentifiqueComando(comando));
        }

        [Theory]
        [InlineData("ACESSE(gmail.com).")]
        [InlineData("ACESSE(gmail.com)]")]
        public void CaractereAposFinalizarParametroComSucesso(string linha)
        {
            Assert.True(Tokenizar.ValideFinalParametro(linha));
        }

        [Theory]
        [InlineData("ACESSE(gmail.com)")]
        [InlineData("ACESSE(gmail.com)AGUARDE")]
        public void CaractereAposFinalizarParametroComFalha(string linha)
        {
            Assert.False(Tokenizar.ValideFinalParametro(linha));
        }

        [Theory]
        [InlineData("[ACESSE(gmail.com)]")]
        public void ValideFinalizacaoComandoSucesso(string linha)
        {
            Assert.True(Tokenizar.ValideFinalParametro(linha));
        }

        [Theory]
        [InlineData("[ACESSE(gmail.com)]")]
        [InlineData("[ACESSE()]")]
        public void ValideParametrosSucesso(string linha)
        {
            Assert.True(Tokenizar.ValideParametroDoComando(linha));
        }

        [Theory]
        [InlineData("[ACESSE(]")]
        [InlineData("[ACESSE)]")]
        public void ValideParametrosFalha(string linha)
        {
            Assert.False(Tokenizar.ValideParametroDoComando(linha));
        }
        
        [Theory]
        [InlineData("ID()", "CLASSE()", "AGUARDE(100)", "NOVOTEXTO()")]
        [InlineData("ACESSE()")]
        public void GetComandos(params string[] comandos)
        {
            var comandosTratados = Tokenizar.GetComandos(comandos.ToList());
            Array.ForEach(comandos, comandoParametro => { Assert.Contains(comandoParametro, comandosTratados); });
        }
    }
}