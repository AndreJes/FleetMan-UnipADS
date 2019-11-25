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
            try
            {
                return Context.Financas.OrderBy(f => f.FinancaId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Financa ObterFinancaPorId(long? id)
        {
            try
            {
                return Context.Financas.Where(f => f.FinancaId == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GravarFinanca(Financa financa)
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoverFinancaPorId(long? id)
        {
            try
            {
                Financa financa = ObterFinancaPorId(id);
                Context.Financas.Remove(financa);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
