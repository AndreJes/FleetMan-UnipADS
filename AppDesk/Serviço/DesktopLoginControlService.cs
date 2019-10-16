using Modelo.Classes.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDesk.Serviço
{
    public static class DesktopLoginControlService
    {
        public static UsuarioFunc Usuario { get; set; }

        public static bool Logar(string email, string senha)
        {
            UsuarioFunc usuarioFunc = ServicoDados.ServicoDadosUsuarioF.ObterUsuarioFuncPorEmail(email);
            if(usuarioFunc != null)
            {
                if(usuarioFunc.Senha == senha)
                {
                    Usuario = usuarioFunc;
                    return true;
                }
                else
                {
                    throw new Exception("Senha Invalida!");
                }
            }
            else
            {
                throw new Exception("Usuário não encontrado!" + Environment.NewLine + "Cheque se o email foi digitado corretamente e tente novamente!");
            }
        }
    }
}
