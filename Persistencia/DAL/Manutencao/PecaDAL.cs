using Modelo.Classes.Manutencao;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Manutencao
{
    public class PecaDAL
    {
        public IEnumerable<Peca> ObterPecasOrdPorId()
        {
            using EFContext Context = new EFContext();
            return Context.Pecas.OrderBy(p => p.PecaId).ToList();
        }

        public Peca ObterPecaPorId(long? id)
        {
            using EFContext Context = new EFContext();
            return Context.Pecas.Where(p => p.PecaId == id).Include(p => p.Fornecedor).FirstOrDefault();
        }

        public void GravarPeca(Peca peca)
        {
            using EFContext Context = new EFContext();
            if (peca.PecaId == null)
            {
                Context.Pecas.Add(peca);
            }
            else
            {
                AttachItem(peca, Context);
                Context.Entry(peca).State = EntityState.Modified;
            }
            Context.SaveChanges();
        }

        public void RemoverPecaPorId(long? id)
        {
            using EFContext Context = new EFContext();
            Peca peca = ObterPecaPorId(id);
            AttachItem(peca, Context);
            Context.Pecas.Remove(peca);
            Context.SaveChanges();
        }

        private void AttachItem(Peca peca, EFContext Context)
        {
            if (!Context.Pecas.Local.Contains(peca))
            {
                Context.Pecas.Attach(peca);
            }
        }
    }
}
