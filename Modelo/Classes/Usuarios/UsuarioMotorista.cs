using Modelo.Classes.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Usuarios
{
    public class UsuarioMotorista : Usuario
    {
        [Key, ForeignKey("Motorista")]
        public long? MotoristaId { get; set; }
        public Motorista Motorista { get; set; }
    }
}
