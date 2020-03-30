﻿using DMTestWebAuto.WebDriver.Drivers;
using DMTestWebAuto.WebDriver.Exceptions;
using DMTestWebAuto.WebDriver.Seletores;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DMTestWebAuto.WebDriver.Test
{
    public class IDSeletorTest
    {
        [Theory]
        [InlineData("http://www.google.com", "cst")]
        public void SeletorPorClasse(string url, string id)
        {
            using var driver = FabricaDriver.Crie(Browser.Chrome, PathDriver.Get);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(2000);
            driver.Navigate().GoToUrl(url);

            var seletor = new IDSeletor(driver, id);

            var element = seletor.Seletor();

            Assert.NotNull(element);
        }

        [Theory]
        [InlineData("http://www.google.com", "xpo")]
        public void SeletorPorClasseNaoEncontrado(string url, string id)
        {
            using var driver = FabricaDriver.Crie(Browser.Chrome, PathDriver.Get);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(2000);
            driver.Navigate().GoToUrl(url);

            var seletor = new IDSeletor(driver, id);

            Exception ex = Assert.Throws<SeletorNaoEncontradoException>(() => seletor.Seletor());

            Assert.IsType<SeletorNaoEncontradoException>(ex);
        }
    }
}
