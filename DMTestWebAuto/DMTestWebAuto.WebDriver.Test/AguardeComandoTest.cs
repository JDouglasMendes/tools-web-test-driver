using DMTestWebAuto.WebDriver.Comandos;
using DMTestWebAuto.WebDriver.Drivers;
using NSubstitute;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace DMTestWebAuto.WebDriver.Test
{
    public class AguardeComandoTest
    {
        [Theory]
        [InlineData(2000)]
        public void Aguarde(int tempo)
        {
            using var driver = Substitute.For<IWebDriver, IDisposable>();
            var aguarde = new AguardeComandoDriver();
            var sw = new Stopwatch();
            sw.Start();
            aguarde.Execute(tempo);
            sw.Stop();
            var ts = sw.Elapsed;
            Assert.True(ts.Seconds >= TimeSpan.FromMilliseconds(tempo).Seconds);
        }
    }
}
