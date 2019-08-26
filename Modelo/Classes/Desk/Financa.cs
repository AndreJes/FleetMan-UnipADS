using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Desk
{
    public class Financa
    {
        public long? FinancaId { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        public EstadosDePagamento EstadoPagamento{ get; set; }
        public TipoDeFinanca Tipo { get; set; }

    }
}
