using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Relatorios
{
    public class RelatorioManutencao : Relatorio
    {
        public int QntTotalMan { get; set; }

        public int QntManAguardando { get; set; }
        public int QntManConcluidas { get; set; }
        public int QntManCanceladas { get; set; }
        public int QntManAgendadas { get; set; }

        public int QntManPreventivas { get; set; }
        public int QntManCorretivas { get; set; }
    }
}
