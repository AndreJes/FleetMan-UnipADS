using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Modelo.Classes.Usuarios;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Usuarios.Web
{
    public class GerenciadorUsuarios : UserManager<UsuarioCliente>
    {
        public GerenciadorUsuarios(IUserStore<UsuarioCliente> store) : base(store)
        {

        }

        public static GerenciadorUsuarios Create(IdentityFactoryOptions<GerenciadorUsuarios> options, IOwinContext context)
        {
            IdentityContext db = context.Get<IdentityContext>();
            GerenciadorUsuarios gerenciador = new GerenciadorUsuarios(new UserStore<UsuarioCliente>(db));
            return gerenciador;
        }
    }
}
