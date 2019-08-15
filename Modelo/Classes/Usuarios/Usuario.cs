using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Usuarios
{
    abstract class Usuario
    {
        public long? UsuarioId { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
