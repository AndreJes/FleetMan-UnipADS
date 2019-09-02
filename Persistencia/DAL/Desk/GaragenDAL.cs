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
            return Context.Garagens.OrderBy(g => g.GaragemId);
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
    }
}
