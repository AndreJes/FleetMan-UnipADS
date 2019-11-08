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

        public RelatorioMulta() { }

        public RelatorioMulta(DateTime dataInicio, DateTime dataFinal, TiposRelatorios tipo, List<Multa> multas, string descricao = "") 
            : base(dataInicio, dataFinal, tipo, descricao:descricao)
        {
            QntTotalMultas = multas.Count();

            QntMultasVencidas = multas.Where(m => m.EstadoDoPagamento == EstadosDePagamento.VENCIDO).Count();
            QntMultasPagas = multas.Where(m => m.EstadoDoPagamento == EstadosDePagamento.PAGO).Count();
            QntMultasAguardando = multas.Where(m => m.EstadoDoPagamento == EstadosDePagamento.AGUARDANDO).Count();

            QntMultasLeves = multas.Where(m => m.GravidadeDaInfracao == GravidadesDeInfracao.LEVE).Count();
            QntMultasMedias = multas.Where(m => m.GravidadeDaInfracao == GravidadesDeInfracao.MEDIA).Count();
            QntMultasGraves = multas.Where(m => m.GravidadeDaInfracao == GravidadesDeInfracao.GRAVE).Count();
            QntMultasGravissimas = multas.Where(m => m.GravidadeDaInfracao == GravidadesDeInfracao.GRAVISSIMA).Count();

            if (QntMultasLeves >= QntMultasMedias && QntMultasLeves >= QntMultasGraves && QntMultasLeves >= QntMultasGravissimas)
            {
                GravidadeMaisComum = GravidadesDeInfracao.LEVE;
            }
            else if (QntMultasMedias >= QntMultasGraves && QntMultasMedias >= QntMultasGravissimas)
            {
                GravidadeMaisComum = GravidadesDeInfracao.MEDIA;
            }
            else if (QntMultasGraves >= QntMultasGravissimas)
            {
                GravidadeMaisComum = GravidadesDeInfracao.GRAVE;
            }
            else
            {
                GravidadeMaisComum = GravidadesDeInfracao.GRAVISSIMA;
            }

            foreach (Multa multa in multas)
            {
                ValorTotal += multa.Valor;
            }

            ValorMedio = ValorTotal / QntTotalMultas;

        }


    }
}
