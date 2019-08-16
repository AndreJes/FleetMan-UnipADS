using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Relatorios
{
    public class RelatorioManutencao : Relatorio
    {
        public List<Manutencao.Manutencao> Manutencoes { get; set; }
    }
}
