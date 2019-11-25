using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validacao
{
    public static class Validador
    {
        public static async Task<bool> ValidarTextoAsync(string texto)
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

        public static async Task<bool> ValidarNumeroAsync(string numero)
        {
            bool resultado = await Task.Run(() =>
            {
                foreach (char c in numero.ToCharArray())
                {
                    if (!char.IsDigit(c))
                    {
                        if (char.IsLetter(c))
                        {
                            if (numero.Length == 1)
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
                foreach (char c in cep.ToCharArray())
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

        public static async Task<bool> ValidarCPFCNPJAsync(string text)
        {
            bool resultado = await Task<bool>.Run(() =>
            {
                foreach (char c in text.ToCharArray())
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

        public async static Task<bool> ValidarEmailAsync(string email)
        {
            bool resultado = await Task.Run(() =>
            {
                if (!email.Contains('@'))
                {
                    return false;
                }
                else if (email.Substring(email.IndexOf('@')).Contains('.'))
                {
                    int dotcount = 0;
                    int arrcount = 0;
                    foreach (char c in email.Substring(email.IndexOf('@')).ToCharArray())
                    {
                        if (c == '.')
                        {
                            dotcount++;
                        }
                        else if (c == '@')
                        {
                            arrcount++;
                        }

                        if (dotcount > 1 || arrcount > 1)
                        {
                            return false;
                        }
                    }

                    if (email.Last() == '.')
                    {
                        return false;
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            });

            return resultado;
        }

        public static async Task<bool> ValidarTelefoneAsync(string telefone)
        {
            bool resultado = await Task.Run(() =>
            {
                if(telefone.Length < 10)
                {
                    return false;
                }
                foreach (char c in telefone.ToCharArray())
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

        public static async Task<bool> ValidarPlacaVeiculoAsync(string placa)
        {
            try
            {
                return await Task.Run(() =>
                {
                    if (placa.Length >= 7)
                    {
                        foreach (char c in placa.Substring(0, 3))
                        {
                            if (!char.IsLetter(c))
                            {
                                return false;
                            }
                        }
                        foreach (char c in placa.Substring(3))
                        {
                            if (!char.IsDigit(c))
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                    return true;
                });
            }
            catch
            {
                return false;
            }
        }
    }
}
