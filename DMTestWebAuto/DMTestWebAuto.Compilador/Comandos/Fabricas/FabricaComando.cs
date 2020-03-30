using DMTestWebAuto.Compilador.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DMTestWebAuto.Compilador.Comandos.Fabricas
{
    public class FabricaComando
    {
        private static volatile FabricaComando instance;
        private static object syncRoot = new object();

        private Dictionary<string, IComando> dicionarioComandos;
        private FabricaComando()
        {
            dicionarioComandos = new Dictionary<string, IComando>();

            Assembly.GetAssembly(typeof(IComando)).GetTypes().ToList().ForEach(x =>
            {
                x.GetCustomAttributes(false).ToList().ForEach(y =>
                {
                    if (y is TokenComandoAttribute idComando)
                    {
                        try
                        {
                            dicionarioComandos.Add(idComando.DescricaoComando, Activator.CreateInstance(x) as IComando);
                        }
                        catch (ArgumentException)
                        {
                            throw new ArgumentException($"existe mais de um interpretador para o comando {idComando.DescricaoComando}!");
                        }                        
                    }
                });
            });
        }
        
        public IComando Crie(string comando)
        {
            if (!dicionarioComandos.ContainsKey(comando))
                throw new ComandoNaoEncontradoException($"O {comando} não é reconhecido");

            return dicionarioComandos[comando];
        }

        public void SetAllContext(IWebDriver webDriver)
        {
            dicionarioComandos.Values.ToList().ForEach(x => x.SetContext(webDriver));
        }

        public static FabricaComando Singleton
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new FabricaComando();
                    }
                }
                return instance;
            }
        }
    }
}
