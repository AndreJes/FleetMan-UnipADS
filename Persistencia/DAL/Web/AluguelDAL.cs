using Modelo.Classes.Web;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Web
{
    public class AluguelDAL : DALContext
    {
        public IEnumerable<Aluguel> ObterAlugueisOrdPorId()
        {
            return Context.Alugueis.OrderBy(a => a.AluguelId);
        }

        public Aluguel ObterAluguelPorId(long? id)
        {
            return Context.Alugueis.Where(a => a.AluguelId == id).FirstOrDefault();
        }

        public void GravarAluguel(Aluguel aluguel)
        {
            if (aluguel.AluguelId == null)
            {
                Context.Alugueis.Add(aluguel);
            }
            else
            {
                Context.Entry(aluguel).State = EntityState.Modified;
            }
            Context.SaveChanges();
        }

        public void RemoverAluguelPorId(long? id)
        {
            Aluguel aluguel = ObterAluguelPorId(id);
            Context.Alugueis.Remove(aluguel);
            Context.SaveChanges();
        }
    }
}
