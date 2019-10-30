using Modelo.Classes.Desk;
using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Relatorios
{
    public class RelatorioMulta : Relatorio
    {
        public int QntTotalMultas { get; set; }

        public int QntMultasVencidas { get; set; }
        public int QntMultasPagas { get; set; }
        public int QntMultasAguardando { get; set; }

        public double ValorTotal { get; set; }
        public double ValorMedio { get; set; }

        public int QntMultasLeves { get; set; }
        public int QntMultasMedias { get; set; }
        public int QntMultasGraves { get; set; }
        public int QntMultasGravissimas { get; set; }

        public GravidadesDeInfracao GravidadeMaisComum { get; set; }
    }
}
