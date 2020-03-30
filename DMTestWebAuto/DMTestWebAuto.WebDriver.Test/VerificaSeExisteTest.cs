using DMTestWebAuto.WebDriver.Drivers;
using DMTestWebAuto.WebDriver.Verificacoes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DMTestWebAuto.WebDriver.Test
{
    public class VerificaSeExisteTest
    {
        [Theory]
        [InlineData("https://globoesporte.globo.com", "glb-topo")]
        public void VerificaSeExiste(string url, string id)
        {
            using var driver = FabricaDriver.Crie(Browser.Chrome, PathDriver.Get);

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(2000);
            driver.Navigate().GoToUrl(url);

            var verifica = new VerificaSeExiste(driver);
            verifica.Verifique(id);
        }
    }
}
