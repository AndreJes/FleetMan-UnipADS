using Modelo.Classes.Web;
using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Relatorios
{
    public class RelatorioViagem : Relatorio
    {
        public int QntTotalViagens { get; set; }

        public int QntViagensAguardando { get; set; }
        public int QntViagensEmAndamento { get; set; }
        public int QntViagensConcluidas{ get; set; }
        public int QntViagensCanceladas { get; set; }

        public RelatorioViagem() { }

        public RelatorioViagem(DateTime dataInicio, DateTime dataFinal, TiposRelatorios tipo, List<Viagem> viagens , string descricao = "")
            : base(dataInicio, dataFinal, tipo, descricao)
        {
            QntTotalViagens = viagens.Count;
            QntViagensAguardando = viagens.Where(v => v.EstadoDaViagem == EstadosDeViagem.AGUARDANDO_INICIO).Count();
            QntViagensEmAndamento = viagens.Where(v => v.EstadoDaViagem == EstadosDeViagem.EM_ANDAMENTO).Count();
            QntViagensConcluidas = viagens.Where(v => v.EstadoDaViagem == EstadosDeViagem.CONCLUIDA).Count();
            QntViagensCanceladas = viagens.Where(v => v.EstadoDaViagem == EstadosDeViagem.CANCELADA).Count();
        }
    }
}
