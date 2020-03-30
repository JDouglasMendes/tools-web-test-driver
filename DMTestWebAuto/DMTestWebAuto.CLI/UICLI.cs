using DMTestWebAuto.Compilador.Compiladores;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DMTestWebAuto.CLI
{
    public class UICLI : IDisposable
    {
        private CompiladorCLI Compilador { get; } 
        private IConfiguration _configuration { get; }
        public UICLI()
        {
            Show("Carregando configurações do Driver...");
            _configuration = PathWebDriver();
            Compilador = new CompiladorCLI(_configuration.GetSection("Selenium:CaminhoDriverChrome").Value);                       
        }

        private static IConfiguration PathWebDriver()
        {
            IConfiguration _configuration = null;

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
            return _configuration;
        }

        public void ExecuteComandos()
        {
            Show("Tudo pronto! Aproveite...");
            View();
        }

        private void View()
        {
            var linha = Console.ReadLine();
            if (!string.IsNullOrEmpty(linha))
            {
                try
                {
                    var resultado = Compilador.ExecuteComando(linha);
                    Show(resultado);
                }
                catch (Exception ex)
                {
                    Show(ex.Message);
                }
                
            }

            if(string.IsNullOrEmpty(linha))
                View();

            if ("sair,exit".Contains(linha.ToLower().Trim()))
                return;

            View();
        }

        static void Show(string mensagem)
        {
            Console.WriteLine(mensagem);
        }
        public void Dispose()
        {
            Compilador.Dispose();
        }

       
    }
}
