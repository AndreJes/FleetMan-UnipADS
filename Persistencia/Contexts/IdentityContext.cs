using Microsoft.AspNet.Identity.EntityFramework;
using Modelo.Classes.Usuarios;
using Persistencia.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Contexts
{
    public class IdentityContext : IdentityDbContext<UsuarioCliente>
    {
        public IdentityContext() : base("Banco_Pim_IV")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EFContext, IdentityConfig>());
        }

        public static IdentityContext Create()
        {
            return new IdentityContext();
        }

    }
}
