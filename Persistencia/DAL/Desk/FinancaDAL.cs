using Modelo.Classes.Desk;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Desk
{
    public class FinancaDAL : DALContext
    {
        public IEnumerable<Financa> ObterFinancasOrdPorId()
        {
            return Context.Financas.OrderBy(f => f.FinancaId);
        }

        public Financa ObterFinancaPorId(long? id)
        {
            return Context.Financas.Where(f => f.FinancaId == id).FirstOrDefault();
        }

        public void GravarFinanca(Financa financa)
        {
            if (financa.FinancaId == null)
            {
                Context.Financas.Add(financa);
            }
            else
            {
                Context.Entry(financa).State = EntityState.Modified;
            }

            Context.SaveChanges();
        }

        public void RemoverFinancaPorId(long? id)
        {
            Financa financa = ObterFinancaPorId(id);
            Context.Financas.Remove(financa);
            Context.SaveChanges();
        }
    }
}
