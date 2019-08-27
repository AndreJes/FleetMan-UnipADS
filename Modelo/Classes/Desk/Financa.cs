using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Desk
{
    public class Financa
    {
        #region Props principais
        public long? FinancaId { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime? DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public EstadosDePagamento EstadoPagamento{ get; set; }
        public TipoDeFinanca Tipo { get; set; }
        #endregion

        #region Props não mapeadas
        [NotMapped]
        public string EstadoPagamentoTxt
        {
            get
            {
                switch (EstadoPagamento)
                {
                    case EstadosDePagamento.PAGO:
                        return "Pago";
                    case EstadosDePagamento.VENCIDO:
                        return "Vencido";
                    case EstadosDePagamento.AGUARDANDO_PAGAMENTO:
                        return "Aguardando";
                    default:
                        return "Pagamento Inválido";
                }
            }
        }
        #endregion

    }
}
