using Modelo.Classes.Manutencao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Relatorios
{
    class RelatorioConsumo : Relatorio
    {
        public List<Abastecimento> Abastecimentos { get; set; }
    }
}
