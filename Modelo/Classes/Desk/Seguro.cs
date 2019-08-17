using Modelo.Classes.Web;
using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Desk
{
    public class Seguro
    {
        public long? SeguroId { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public double PrecoParcela { get; set; }
        public DateTime DataVencimentoParcela { get; set; }
        public DateTime DataContratacao { get; set; }
        public DateTime Vencimento_Contrato { get; set; }
        public EstadosDePagamento EstadoPagamento { get; set; }

        public long? VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}
