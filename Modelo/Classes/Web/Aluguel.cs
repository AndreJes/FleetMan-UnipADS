using Modelo.Classes.Clientes;
using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Web
{
    public class Aluguel
    {
        public long? AluguelId { get; set; }
        public DateTime DataContratacao { get; set; }
        public DateTime DataVencimento { get; set; }
        public EstadosDePagamento EstadoDoPagamento { get; set; }
        public EstadosAluguel EstadoDoAluguel { get; set; }

        public long? VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }

        public long? ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
