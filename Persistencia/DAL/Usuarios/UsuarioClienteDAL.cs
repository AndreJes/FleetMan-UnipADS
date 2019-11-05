using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Modelo.Classes.Usuarios;
using Persistencia.Contexts;
using Persistencia.DAL.Usuarios.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Usuarios
{
    public class UsuarioClienteDAL
    {
        private GerenciadorUsuarios gerenciador = new GerenciadorUsuarios(new UserStore<UsuarioCliente>(IdentityContext.Create()));

        public void AdicionarUsuarioCliente(UsuarioClienteView usuarioView)
        {
            UsuarioCliente usuario = new UsuarioCliente();
            usuario.Id = usuarioView.ClienteId.ToString();
            usuario.Email = usuarioView.Email;
            usuario.UserName = usuarioView.Email;

            IdentityResult result = gerenciador.Create(usuario, usuarioView.Senha);
        }

        public void RemoverUsuarioClientePorId(string id)
        {
            UsuarioCliente usuarioCliente = gerenciador.FindById(id);
            if (usuarioCliente != null)
            {
                gerenciador.Delete(usuarioCliente);
            }
        }

        public void AlterarUsuarioCliente(string id, string novoEmail = "", string novaSenha = "")
        {
            UsuarioCliente usuario = gerenciador.FindById(id);
            if(!string.IsNullOrEmpty(novoEmail))
            {
                usuario.Email = novoEmail;
                usuario.UserName = novoEmail;
            }
            if(!string.IsNullOrEmpty(novaSenha))
            {
                usuario.PasswordHash = gerenciador.PasswordHasher.HashPassword(novaSenha);
            }
            gerenciador.Update(usuario);
        }
    }
}
