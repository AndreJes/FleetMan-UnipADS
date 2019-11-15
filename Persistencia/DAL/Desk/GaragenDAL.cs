using Modelo.Classes.Desk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Persistencia.DAL.Desk
{
    public class GaragenDAL : DALContext
    {
        public IEnumerable<Garagem> ObterGaragensOrdPorId()
        {
            return Context.Garagens.Include(g => g.Veiculos).OrderBy(g => g.GaragemId);
        }

        public void GravarGaragem(Garagem garagem)
        {
            if(garagem.GaragemId == null)
            {
                Context.Garagens.Add(garagem);
            }
            else
            {
                Context.Entry(garagem).State = EntityState.Modified;
            }
            Context.SaveChanges();
        }

        public Garagem ObterGaragemPorId(long? id)
        {
            Garagem garagem = Context.Garagens.Where(g => g.GaragemId == id).Include(g => g.Veiculos).First();
            return garagem;
        }

        public void RemoverGaragemPorId(long? id)
        {
            Garagem garagem = ObterGaragemPorId(id);
            Context.Garagens.Remove(garagem);
            Context.SaveChanges();
        }
    }
}
