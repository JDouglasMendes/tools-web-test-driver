using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DMTestWebAuto.Compilador.Tokens
{
    public class EnumSeguroComandos
    {
        public EnumComandos EnumComando { get; private set; }
        public string Comando { get; private set; }

        private static Func<FieldInfo, string, bool> VerifiquePorNome = delegate (FieldInfo fi, string nome)
        {
            try
            {
                return ((EnumSeguroComandos)fi.GetValue(new EnumSeguroComandos(EnumComandos.Acesse, string.Empty))).Comando == nome;
            }
            catch (Exception)
            {
                return false;
            }                                        
        };
        private EnumSeguroComandos(EnumComandos enumComando, string comando)
        {
            EnumComando = enumComando;
            Comando = comando;
        }

        public static EnumSeguroComandos Acesse = new EnumSeguroComandos(EnumComandos.Acesse, Constantes.Acesse_Comando);
        public static EnumSeguroComandos Click = new EnumSeguroComandos(EnumComandos.Click, Constantes.Click_Comando);

        public static EnumSeguroComandos GetPorNome(string nome)
        {
            var field = typeof(EnumSeguroComandos).GetFields().ToList().Where(x => VerifiquePorNome(x, nome)).FirstOrDefault();
            return (EnumSeguroComandos)field?.GetValue(null);
        }

        public override bool Equals(object obj)
        {
            try
            {
                return ((EnumSeguroComandos)obj).EnumComando == EnumComando;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(EnumComando, Comando);
        }
    };
    
    
}
