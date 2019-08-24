using Modelo.Classes.Web;
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
        public ushort QntEnvolvidos { get; set; }
        public EstadosDePagamento EstadoPagamento { get; set; }
        public GravidadesDeSinistro Gravidade { get; set; }

        public long? VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }

        public long? MotoristaId { get; set; }
        public Motorista Motorista { get; set; }
    }
}
