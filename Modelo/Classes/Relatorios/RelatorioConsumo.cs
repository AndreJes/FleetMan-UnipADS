using Modelo.Classes.Manutencao;
using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Relatorios
{
    public class RelatorioConsumo : Relatorio
    {
        public int QntVeiculosAbastecidos { get; set; }

        public double TotalCombustivel { get; set; }
        public double MediaDeCombustivel { get; set; }

        public double ValorGastoTotal { get; set; }
        public double ValorGastoMedio { get; set; }

        public RelatorioConsumo(DateTime dataInicio, DateTime dataFinal, TiposRelatorios tipo, List<Abastecimento> abastecimentos, string descricao = "")
            : base (dataInicio, dataFinal, tipo, descricao:descricao)
        {
            double totalCombustivel = 0;
            double media = 0;
            double valorTotal = 0;
            double valorMedio = 0;

            QntVeiculosAbastecidos = abastecimentos.Count;

            foreach (Abastecimento a in abastecimentos)
            {
                if(a.QuantidadeAbastecida != null)
                {
                    totalCombustivel += (double)a.QuantidadeAbastecida;
                }
                if(a.Valor != null)
                {
                    valorTotal += (double)a.Valor;
                }
            }

            media = totalCombustivel / QntVeiculosAbastecidos;
            valorMedio = valorTotal / QntVeiculosAbastecidos;

            TotalCombustivel = totalCombustivel;
            MediaDeCombustivel = media;
            ValorGastoTotal = valorTotal;
            ValorGastoMedio = valorMedio;
        }

    }
}
