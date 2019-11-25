using Modelo.Classes.Desk;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Desk
{
    public class MultaDAL : DALContext
    {
        public IEnumerable<Multa> ObterMultasOrdPorId()
        {
            try
            {
                return Context.Multas.OrderBy(m => m.MultaId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Multa ObterMultaPorId(long? id)
        {
            try
            {
                return Context.Multas.Where(m => m.MultaId == id).Include(m => m.Veiculo).Include(m => m.Motorista).First();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GravarMulta(Multa multa)
        {
            try
            {
                if (multa.MultaId == null)
                {
                    Context.Multas.Add(multa);
                }
                else
                {
                    Context.Entry(multa).State = EntityState.Modified;
                }
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoverMultaPorId(long? id)
        {
            try
            {
                Multa multa = ObterMultaPorId(id);
                Context.Multas.Remove(multa);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
