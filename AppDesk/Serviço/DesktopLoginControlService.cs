using Modelo.Classes.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppDesk.Serviço
{
    public static class DesktopLoginControlService
    {
        public static UsuarioFunc _Usuario { get; private set; }

        public static bool Logar(string email, string senha)
        {
            UsuarioFunc usuarioFunc = ServicoDados.ServicoDadosUsuarioF.ObterUsuarioFuncPorEmail(email);

            if (usuarioFunc != null && usuarioFunc.Login == email)
            {
                if (usuarioFunc.Senha == senha)
                {
                    _Usuario = usuarioFunc;
                    return true;
                }
                else
                {
                    throw new FieldException("Senha Invalida!");
                }
            }
            else
            {
                throw new Exception("Usuário não encontrado!" + Environment.NewLine + "Cheque se o email foi digitado corretamente e tente novamente!");
            }
        }

        public static void Deslogar()
        {
            foreach (Window w in Application.Current.Windows)
            {
                if (!(w is MainWindow))
                {
                    w.Close();
                }
            }
            _Usuario = null;
        }
    }
}
