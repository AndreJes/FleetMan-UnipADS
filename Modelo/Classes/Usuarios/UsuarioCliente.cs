using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Usuarios
{
    public class UsuarioCliente : Usuario
    {
        public long? ClienteId { get; set; }
        public Clientes.Cliente Cliente { get; set; }
    }
}
