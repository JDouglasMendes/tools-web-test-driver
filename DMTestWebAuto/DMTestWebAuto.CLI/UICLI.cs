using DMTestWebAuto.Compilador.Compiladores;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Timers;

namespace DMTestWebAuto.CLI
{
    public class UICLI : IDisposable
    {
        private CompiladorCLI Compilador { get; } 
        private IConfiguration _configuration { get; }
        public UICLI()
        {
            ShowLogo("");
            InicieMensagemTemporizada();
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

        private void InicieMensagemTemporizada()
        {
            aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;            
        }
        private System.Timers.Timer aTimer;
        private int count = 0;
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            count++;                   
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write($"Carregando configurações do Driver {count}s" );
        }


        public void ExecuteComandos()
        {
            Console.CursorVisible = true;
            aTimer.Stop();
            aTimer.Dispose();
            Console.WriteLine();
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

        static void ShowBot(string message)
        {
            string bot = $"\n        {message}";
            bot += @"
    __________________
                      \
                       \
                          ....
                          ....'
                           ....
                        ..........
                    .............'..'..
                 ................'..'.....
               .......'..........'..'..'....
              ........'..........'..'..'.....
             .'....'..'..........'..'.......'.
             .'..................'...   ......
             .  ......'.........         .....
             .    _            __        ......
            ..    #            ##        ......
           ....       .                 .......
           ......  .......          ............
            ................  ......................
            ........................'................
           ......................'..'......    .......
        .........................'..'.....       .......
     ........    ..'.............'..'....      ..........
   ..'..'...      ...............'.......      ..........
  ...'......     ...... ..........  ......         .......
 ...........   .......              ........        ......
.......        '...'.'.              '.'.'.'         ....
.......       .....'..               ..'.....
   ..       ..........               ..'........
          ............               ..............
         .............               '..............
        ...........'..              .'.'............
       ...............              .'.'.............
      .............'..               ..'..'...........
      ...............                 .'..............
       .........                        ..............
        .....
";
            Console.WriteLine(bot);
        }

        private void ShowLogo(string message)
        {
            string text = string.Empty;
            text += @"
          \\           // ||======= ||=======))          			 
           \\         //  ||        ||        ))               	      
─▄██▄██▄    \\   /\  //   ||===     ||=======))            
─▀█████▀     \\ //\\//    ||        ||        ))	       
───▀█▀	      \\/  \/     ||======= ||=======)) 
";
            text += $"\n{message}";
            Console.WriteLine(text);
        }

    }
}
