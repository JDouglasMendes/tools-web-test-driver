using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DMTestWebAuto.Compilador.Test
{
    public class PathDriver
    {
        public static string Get
        {
            get
            {
                IConfiguration _configuration = null;

                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

                _configuration = builder.Build();

                return _configuration.GetSection("Selenium:CaminhoDriverChrome").Value;

            }
        }
    }
}
