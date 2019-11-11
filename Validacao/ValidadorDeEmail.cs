using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validacao
{
    public static class ValidadorDeEmail
    {
        public async static Task<bool> ValidarEmail(string email)
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
                        else if(c == '@')
                        {
                            arrcount++;
                        }

                        if (dotcount > 1 || arrcount > 1)
                        {
                            return false;
                        }
                    }

                    if(email.Last() == '.')
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
    }
}
