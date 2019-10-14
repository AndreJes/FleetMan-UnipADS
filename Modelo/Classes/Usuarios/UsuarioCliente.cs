using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Usuarios
{
    public class UsuarioCliente : Usuario
    {
        [Key, ForeignKey("Cliente")]
        public long? ClienteId { get; set; }
        public Clientes.Cliente Cliente { get; set; }
    }
}
