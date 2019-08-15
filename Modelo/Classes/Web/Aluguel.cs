using Modelo.Classes.Clientes;
using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Web
{
    class Aluguel
    {
        public long? AluguelId { get; set; }
        public DateTime DataContratacao { get; set; }
        public DateTime DataVencimento { get; set; }
        public EstadosDePagamento EstadoDoPagamento { get; set; }
        public EstadosAluguel EstadoDoAluguel { get; set; }

        public long IdVeiculoAlugado { get; set; }
        public Veiculo VeiculoAlugado { get; set; }

        public long IdCliente { get; set; }
        public Cliente Cliente { get; set; }
    }
}
