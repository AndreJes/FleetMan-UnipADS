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
        public int TotalDeEnvolvidos { get; set; }

        public int QntSinistrosVencidos { get; set; }
        public int QntSinistrosPagos { get; set; }
        public int QntSinistrosAguardando { get; set; }

        public int QntBatidas { get; set; }
        public int QntAcidentesLevesCVitima { get; set; }
        public int QntAcidentesLevesSVitima { get; set; }
        public int QntAcidentesGraves { get; set; }
        public int QntAcidentesFatais { get; set; }
        public int QntPerdasTotais { get; set; }

        public GravidadesDeSinistro GravidadeMaisComum { get; set; }

        public RelatorioSinistros(){ }

        public RelatorioSinistros(DateTime dataInicio, DateTime dataFinal, TiposRelatorios tipo, List<Sinistro> sinistros, string descricao = "")
            : base(dataInicio, dataFinal, tipo, descricao: descricao)
        {
            QntTotalSinistros = sinistros.Count;

            foreach (Sinistro s in sinistros)
            {
                TotalDeEnvolvidos += s.QntEnvolvidos;
            }

            QntSinistrosVencidos = sinistros.Where(s => s.EstadoPagamento == EstadosDePagamento.VENCIDO).Count();
            QntSinistrosPagos = sinistros.Where(s => s.EstadoPagamento == EstadosDePagamento.PAGO).Count();
            QntSinistrosAguardando = sinistros.Where(s => s.EstadoPagamento == EstadosDePagamento.AGUARDANDO_PAGAMENTO).Count();

            QntBatidas = sinistros.Where(s => s.Gravidade == GravidadesDeSinistro.BATIDA).Count();
            QntAcidentesLevesCVitima = sinistros.Where(s => s.Gravidade == GravidadesDeSinistro.ACIDENTE_LEVE_COM_VITIMA).Count();
            QntAcidentesLevesSVitima = sinistros.Where(s => s.Gravidade == GravidadesDeSinistro.ACIDENTE_LEVE_SEM_VITIMA).Count();
            QntAcidentesGraves = sinistros.Where(s => s.Gravidade == GravidadesDeSinistro.ACIDENTE_GRAVE).Count();
            QntAcidentesFatais = sinistros.Where(s => s.Gravidade == GravidadesDeSinistro.ACIDENTE_FATAL).Count();
            QntPerdasTotais = sinistros.Where(s => s.Gravidade == GravidadesDeSinistro.PERDA_TOTAL).Count();

        }
    }
}
