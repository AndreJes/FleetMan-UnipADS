using Modelo.Classes.Web;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Web
{
    public class SolicitacaoDAL
    {
        public IEnumerable<Solicitacao> ObterSolicitacoesOrdPorId()
        {
            using EFContext Context = new EFContext();
            return Context.Solicitacoes.OrderBy(s => s.SolicitacaoId).ToList();
        }

        public Solicitacao ObterSolicitacaoPorId(long? id)
        {
            using EFContext Context = new EFContext();
            return Context.Solicitacoes.Where(s => s.SolicitacaoId == id).FirstOrDefault();
        }

        public void GravarSolicitacao(Solicitacao solicitacao)
        {
            using EFContext Context = new EFContext();
            if (solicitacao.SolicitacaoId == null)
            {
                Context.Solicitacoes.Add(solicitacao);
            }
            else
            {
                AttachItem(solicitacao, Context);
                Context.Entry(solicitacao).State = EntityState.Modified;
            }

            Context.SaveChanges();
        }

        public void RemoverSolicitacaoPorId(long? id)
        {
            using EFContext Context = new EFContext();
            Solicitacao solicitacao = ObterSolicitacaoPorId(id);
            AttachItem(solicitacao, Context);
            Context.Solicitacoes.Remove(solicitacao);
            Context.SaveChanges();
        }

        private void AttachItem(Solicitacao solicitacao, EFContext context)
        {
            if (!context.Solicitacoes.Local.Contains(solicitacao))
            {
                context.Solicitacoes.Attach(solicitacao);
            }
        }
    }
}
