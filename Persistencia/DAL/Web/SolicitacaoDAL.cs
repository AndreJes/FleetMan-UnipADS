using Modelo.Classes.Web;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Web
{
    public class SolicitacaoDAL : DALContext
    {
        public IEnumerable<Solicitacao> ObterSolicitacoesOrdPorId()
        {
            return Context.Solicitacoes.OrderBy(s => s.SolicitacaoId).ToList();
        }

        public Solicitacao ObterSolicitacaoPorId(long? id)
        {
            return Context.Solicitacoes.Where(s => s.SolicitacaoId == id).FirstOrDefault();
        }

        public void GravarSolicitacao(Solicitacao solicitacao)
        {
            if (solicitacao.SolicitacaoId == null)
            {
                Context.Solicitacoes.Add(solicitacao);
            }
            else
            {
                Context.Entry(solicitacao).State = EntityState.Modified;
            }

            Context.SaveChanges();
        }

        public void RemoverSolicitacaoPorId(long? id)
        {
            Solicitacao solicitacao = ObterSolicitacaoPorId(id);
            Context.Solicitacoes.Remove(solicitacao);
            Context.SaveChanges();
        }
    }
}
