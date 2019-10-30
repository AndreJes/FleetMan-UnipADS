using Modelo.Classes.Manutencao;
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
    }
}
