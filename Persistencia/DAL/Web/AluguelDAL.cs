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
            try
            {
                return Context.Alugueis.Include(a => a.Veiculo).OrderBy(a => a.AluguelId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Aluguel ObterAluguelPorId(long? id)
        {
            try
            {
                return Context.Alugueis.Where(a => a.AluguelId == id).Include(a => a.Cliente).Include(a => a.Veiculo).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GravarAluguel(Aluguel aluguel)
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoverAluguelPorId(long? id)
        {
            try
            {
                Aluguel aluguel = ObterAluguelPorId(id);
                Context.Alugueis.Remove(aluguel);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
