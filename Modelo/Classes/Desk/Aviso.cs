using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Desk
{
    public class Aviso
    {
        public long? AvisoId { get; set; }
        public string Mensagem { get; set; }
        public TiposDeAviso Tipo { get; set; }
    }
}
