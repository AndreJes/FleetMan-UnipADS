using Modelo.Classes.Auxiliares;
using Modelo.Classes.Web;
using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Manutencao
{
    public class Abastecimento
    {
        [Key]
        public long? AbastecimentoId { get; set; }

        public double? QuantidadeAbastecida { get; set; }
        public double? Valor { get; set; }
        public DateTime? DataAgendada { get; set; }
        public DateTime? DataConclusao { get; set; }
        public Endereco Local { get; set; }

        public EstadoAbastecimento Estado { get; set; }
        public EstadosTanqueCombustivel? NovoEstadoTanque { get; set; }

        public long? MotoristaId { get; set; }
        public Motorista Motorista { get; set; }

        public long? VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}
