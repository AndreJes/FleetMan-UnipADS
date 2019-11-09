using Modelo.Classes.Clientes;
using Modelo.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Web
{
    public class Aluguel
    {
        #region Props principais
        public long? AluguelId { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataContratacao { get; set; }
        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de Vencimento")]
        public DateTime DataVencimento { get; set; }

        public EstadosDePagamento EstadoDoPagamento { get; set; }
        public EstadosAluguel EstadoDoAluguel { get; set; }
        #endregion

        #region Props não mapeadas
        [NotMapped]
        public string EstadoPagamentoTxt
        {
            get
            {
                switch (EstadoDoPagamento)
                {
                    case EstadosDePagamento.PAGO:
                        return "Pago";
                    case EstadosDePagamento.VENCIDO:
                        return "Pagamento Vencido";
                    case EstadosDePagamento.AGUARDANDO:
                        return "Aguardando Pagamento";
                    default:
                        return "Estado não definido";
                }
            }
        }
        [NotMapped]
        public string EstadoAluguelTxt
        {
            get
            {
                switch (EstadoDoAluguel)
                {
                    case EstadosAluguel.REGULAR:
                        return "Regular";
                    case EstadosAluguel.CANCELADO:
                        return "Cancelado";
                    case EstadosAluguel.VENCIDO:
                        return "Vencido";
                    default:
                        return "Estado não definido";
                }
            }
        }
        #endregion

        public long? VeiculoId { get; set; }
        [JsonIgnore]
        public Veiculo Veiculo { get; set; }

        public long? ClienteId { get; set; }
        [JsonIgnore]
        public Cliente Cliente { get; set; }
    }
}
