using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace DMTestWebAuto.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            using var cli = new UICLI();
            cli.ExecuteComandos();
        }
    }
}
