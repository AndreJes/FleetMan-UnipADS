using Microsoft.AspNet.Identity.EntityFramework;
using Modelo.Classes.Clientes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Usuarios
{
    public class UsuarioCliente : IdentityUser
    {
        [ForeignKey("Cliente")]
        public long? ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
