using Modelo.Enums;
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
        public int QntManEmAndamento { get; set; }

        public int QntManPreventivas { get; set; }
        public int QntManCorretivas { get; set; }

        public RelatorioManutencao(DateTime dataInicio, DateTime dataFinal, TiposRelatorios tipo, List<Modelo.Classes.Manutencao.Manutencao> manutencoes, string descricao = "")
            : base(dataInicio, dataFinal, tipo, descricao:descricao)
        {
            QntTotalMan = manutencoes.Count;
            QntManAguardando = manutencoes.Where(m => m.EstadoAtual == EstadosDeManutencao.AGUARDANDO).Count();
            QntManConcluidas = manutencoes.Where(m => m.EstadoAtual == EstadosDeManutencao.CONCLUIDA).Count();
            QntManCanceladas = manutencoes.Where(m => m.EstadoAtual == EstadosDeManutencao.CANCELADA).Count();
            QntManEmAndamento = manutencoes.Where(m => m.EstadoAtual == EstadosDeManutencao.EM_ANDAMENTO).Count();

            QntManPreventivas = manutencoes.Where(m => m.Tipo == TiposDeManutencao.PREVENTIVA).Count();
            QntManCorretivas = manutencoes.Where(m => m.Tipo == TiposDeManutencao.CORRETIVA).Count();
        }
    }
}
