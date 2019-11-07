using Modelo.Classes.Clientes;
using Modelo.Classes.Web;
using Modelo.Enums;
using Persistencia.DAL.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Servicos.Web
{
    public class SolicitacaoService
    {
        private SolicitacaoDAL Context = new SolicitacaoDAL();

        public IEnumerable<Solicitacao> ObterSolicitacoesOrdPorId()
        {
            return Context.ObterSolicitacoesOrdPorId();
        }

        public Solicitacao ObterSolicitacaoPorId(long? id)
        {
            return Context.ObterSolicitacaoPorId(id);
        }

        public void GravarSolicitacao(Solicitacao solicitacao)
        {
            Context.GravarSolicitacao(solicitacao);
        }

        public Solicitacao GerarSolicitacao(ItemSolicitacao tipoItem, TiposDeSolicitacao tipo, long? clienteId)
        {
            Solicitacao solicitacao = new Solicitacao();
            solicitacao.DataDaSolicitacao = DateTime.Now;
            solicitacao.TipoDeItem = tipoItem;
            solicitacao.Tipo = tipo;
            solicitacao.Estado = EstadosDaSolicitacao.AGUARDANDO;
            solicitacao.ClienteId = clienteId;
            return solicitacao;
        }
    }
}
