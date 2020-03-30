using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMTestWebAuto.WebDriver.Comandos
{
    public class AguardeComandoDriver 
    {        
        public void Execute(int segundos) => System.Threading.Thread.Sleep(segundos);
    }
}
