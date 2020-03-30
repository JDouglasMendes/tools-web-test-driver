using DMTestWebAuto.Compilador.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DMTestWebAuto.Compilador.Test
{
    public class EnumSeguroComandosTest
    {
        [Theory]
        [InlineData("ACESSE", 0)]
        [InlineData("CLICK", 1)]
        public void GetPorNome(string descricao, int comando)
        {
            var resultado = EnumSeguroComandos.GetPorNome(descricao);
            Assert.NotNull(resultado);
            Assert.Equal((int)resultado.EnumComando, comando);
        }
    }
}
