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
            try
            {
                return Context.Garagens.Include(g => g.Veiculos).OrderBy(g => g.GaragemId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GravarGaragem(Garagem garagem)
        {
            try
            {
                if (garagem.GaragemId == null)
                {
                    Context.Garagens.Add(garagem);
                }
                else
                {
                    Context.Entry(garagem).State = EntityState.Modified;
                }
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Garagem ObterGaragemPorId(long? id)
        {
            try
            {
                Garagem garagem = Context.Garagens.Where(g => g.GaragemId == id).Include(g => g.Veiculos).First();
                return garagem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoverGaragemPorId(long? id)
        {
            try
            {
                Garagem garagem = ObterGaragemPorId(id);
                Context.Garagens.Remove(garagem);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
