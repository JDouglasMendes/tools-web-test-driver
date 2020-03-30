using DMTestWebAuto.Compilador.Comandos;
using DMTestWebAuto.Compilador.Comandos.Fabricas;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DMTestWebAuto.Compilador.Test
{
    public class FabricaComandoTest
    {
        [Theory]
        [InlineData("acesse",typeof(AcesseComando))]
        public void TestInstance(string comando, Type typeInstance)
        {
            var resultado = FabricaComando.Singleton.Crie(comando);
            Assert.Equal(typeInstance.FullName, resultado.GetType().FullName);
        }
    }
}
