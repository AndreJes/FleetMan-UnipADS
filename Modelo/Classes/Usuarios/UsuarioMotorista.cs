using Modelo.Classes.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Usuarios
{
    public class UsuarioMotorista : Usuario
    {
        public long? MotoristaId { get; set; }
        public Motorista Motorista { get; set; }
    }
}
