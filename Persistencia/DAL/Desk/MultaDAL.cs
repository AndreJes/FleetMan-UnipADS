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
            return Context.Multas.OrderBy(m => m.MultaId);
        }

        public Multa ObterMultaPorId(long? id)
        {
            return Context.Multas.Where(m => m.MultaId == id).Include(m => m.Veiculo).Include(m => m.Motorista).First();
        }

        public void GravarMulta(Multa multa)
        {
            if(multa.MultaId == null)
            {
                Context.Multas.Add(multa);
            }
            else
            {
                Context.Entry(multa).State = EntityState.Modified;
            }
            Context.SaveChanges();
        }

        public void RemoverMultaPorId(long? id)
        {
            Multa multa = ObterMultaPorId(id);
            Context.Multas.Remove(multa);
            Context.SaveChanges();
        }
    }
}
