using Modelo.Classes.Desk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Relatorios
{
    public class RelatorioFinanceiro: Relatorio
    {
        public int QntTotalFinancas { get; set; }

        public int QntFinancasVencidas { get; set; }
        public int QntFinancasPagas { get; set; }
        public int QntFinancasAguardando { get; set; }

        public double TotalValorEntradas { get; set; }
        public double TotalValorSaidas { get; set; }
    }
}
