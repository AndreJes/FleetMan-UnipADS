using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Desk
{
    public class Sinistro
    {
        public long? SinistroId { get; set; }
        public string CodSinistro { get; set; }
        public string Descricao { get; set; }
        public EstadosDePagamento EstadoPagamento { get; set; }
        public GravidadesDeSinistro Gravidade { get; set; }
    }
}
