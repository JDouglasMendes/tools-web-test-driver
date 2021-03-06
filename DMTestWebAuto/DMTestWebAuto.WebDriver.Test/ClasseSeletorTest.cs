﻿using DMTestWebAuto.WebDriver.Drivers;
using DMTestWebAuto.WebDriver.Exceptions;
using DMTestWebAuto.WebDriver.Seletores;
using NSubstitute;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DMTestWebAuto.WebDriver.Test
{
    public class ClasseSeletorTest
    {
        [Theory]
        [InlineData("http://www.google.com", "gb_g")]
        public void SeletorPorClasse(string url, string classe)
        {
            using var driver = Substitute.For<IWebDriver, IDisposable>();

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(2000);
            driver.Navigate().GoToUrl(url);

            var seletor = new ClasseSeletor(driver, classe);

            var element = seletor.Seletor();

            Assert.NotNull(element);
        }

        [Theory]
        [InlineData("http://www.google.com", "xpo")]        
        public void SeletorPorClasseNaoEncontrado(string url, string classe)
        {
            using var driver = Substitute.For<IWebDriver, IDisposable>();

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(2000);
            driver.Navigate().GoToUrl(url);

            var seletor = new ClasseSeletor(driver, classe);
            driver.FindElement(By.ClassName(classe)).Returns(x => { throw new SeletorNaoEncontradoException(""); });
            Exception ex = Assert.Throws<SeletorNaoEncontradoException>(() => seletor.Seletor());

            Assert.IsType<SeletorNaoEncontradoException>(ex);
        }
    }
}
