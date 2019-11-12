using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validacao
{
    public static class ValidadorEndereco
    {
        public static async Task<bool> ValidarTexto(string texto)
        {
            bool resultado = await Task.Run(() =>
            {
                foreach (char c in texto.ToCharArray())
                {
                    if (!char.IsLetter(c))
                    {
                        if (char.IsWhiteSpace(c))
                        {
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return true;
            });

            return resultado;
        }

        public static async Task<bool> ValidarNumero(string numero)
        {
            bool resultado = await Task.Run(() =>
            {
                foreach (char c in numero.ToCharArray())
                {
                    if (!char.IsDigit(c))
                    {
                        if (char.IsLetter(c))
                        {
                            if(numero.Length == 1)
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return true;
            });

            return resultado;
        }

        
        public static async Task<bool> ValidarCEP(string cep)
        {
            bool resultado = await Task.Run(() =>
            {
                foreach(char c in cep.ToCharArray())
                {
                    if (!char.IsDigit(c))
                    {
                        return false;
                    }
                }
                return true;
            });

            return resultado;
        }
    }
}
