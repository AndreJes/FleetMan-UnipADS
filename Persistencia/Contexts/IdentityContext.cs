using Microsoft.AspNet.Identity.EntityFramework;
using Modelo.Classes.Usuarios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Contexts
{
    public class IdentityContext : IdentityDbContext<UsuarioCliente>
    {
        public IdentityContext() : base("Banco_Pim_IV")
        {
            
        }

        static IdentityContext()
        {
            Database.SetInitializer<IdentityContext>(new IdentityDbInit());
        }

        public static IdentityContext Create()
        {
            return new IdentityContext();
        }

    }

    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<IdentityContext>
    {

    }
}
