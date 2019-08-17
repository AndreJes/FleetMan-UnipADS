using Modelo.Classes.Web;
using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Desk
{
    public class Multa
    {
        public long? MultaId { get; set; }
        public string CodigoMulta { get; set; }
        public double Valor { get; set; }
        public DateTime DataDaMulta { get; set; }
        public EstadosDePagamento EstadoDoPagamento { get; set; }
        public GravidadesDeInfracao GravidadeDaInfracao { get; set; }

        public long? VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }

        public long? MotoristaId { get; set; }
        public Motorista Motorista { get; set; }
    }
}
