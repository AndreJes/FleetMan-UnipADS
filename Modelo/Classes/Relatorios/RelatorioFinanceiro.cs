using Modelo.Classes.Desk;
using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Relatorios
{
    public class RelatorioFinanceiro : Relatorio
    {
        public int QntTotalFinancas { get; set; }

        public int QntFinancasVencidas { get; set; }
        public int QntFinancasPagas { get; set; }
        public int QntFinancasAguardando { get; set; }

        public double TotalValorEntradas { get; set; }
        public double TotalValorSaidas { get; set; }

        public RelatorioFinanceiro() { }

        public RelatorioFinanceiro(DateTime dataInicio, DateTime dataFinal, TiposRelatorios tipo, List<Financa> financas, string descricao = "")
            : base(dataInicio, dataFinal, tipo, descricao: descricao)
        {
            QntTotalFinancas = financas.Count;

            QntFinancasVencidas = financas.Where(f => f.EstadoPagamento == EstadosDePagamento.VENCIDO).Count();
            QntFinancasPagas = financas.Where(f => f.EstadoPagamento == EstadosDePagamento.PAGO).Count();
            QntFinancasAguardando = financas.Where(f => f.EstadoPagamento == EstadosDePagamento.AGUARDANDO).Count();

            double valorTotalEntradas = 0;
            double valorTotalSaidas = 0;

            foreach (Financa f in financas)
            {
                switch (f.Tipo)
                {
                    case TipoDeFinanca.ENTRADA:
                        valorTotalEntradas += f.Valor;
                        break;
                    case TipoDeFinanca.SAIDA:
                        valorTotalSaidas += f.Valor;
                        break;
                    default:
                        break;
                }
            }

            TotalValorEntradas = valorTotalEntradas;
            TotalValorSaidas = valorTotalSaidas;
            
        }


    }
}
