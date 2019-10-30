using Modelo.Classes.Desk;
using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Relatorios
{
    public class RelatorioSinistros : Relatorio
    {
        public int QntTotalSinistros { get; set; }

        public int MediaDeEnvolvidos { get; set; }

        public int QntSinistrosVencidos { get; set; }
        public int QntSininistrosPagos  { get; set; }
        public int QntSinistrosAguardando { get; set; }

        public int QntBatidas { get; set; }
        public int QntAcidentesLevesCVitima { get; set; }
        public int QntAcidentesLevesSVitima { get; set; }
        public int QntAcidentesGraves { get; set; }
        public int QntAcidentesFatais { get; set; }
        public int QntPerdasTotais { get; set; }

        public GravidadesDeSinistro GravidadeMaisComum { get; set; }
    }
}
