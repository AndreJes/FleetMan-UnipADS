using Modelo.Classes.Manutencao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Manutencao
{
    public class PecaDAL: DALContext
    {
        public IEnumerable<Peca> ObterPecasOrdPorId()
        {
            return Context.Pecas.OrderBy(p => p.PecaId).ToList();
        }

        public Peca ObterPecaPorId(long? id)
        {
            return Context.Pecas.Where(p => p.PecaId == id).FirstOrDefault();
        }

        public void GravarPeca(Peca peca)
        {
            if(peca.PecaId == null)
            {
                Context.Pecas.Add(peca);
            }
            else
            {
                Context.Entry(peca).State = EntityState.Modified;
            }
            Context.SaveChanges();
        }

        public void RemoverPecaPorId(long? id)
        {
            Peca peca = ObterPecaPorId(id);
            Context.Pecas.Remove(peca);
            Context.SaveChanges();
        }
    }
}
