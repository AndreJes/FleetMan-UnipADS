using Modelo.Classes.Desk;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Desk
{
    public class FinancaDAL
    {
        public IEnumerable<Financa> ObterFinancasOrdPorId()
        {
            try
            {
                using EFContext Context = new EFContext();
                return Context.Financas.OrderBy(f => f.FinancaId).ToList();
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
                using EFContext Context = new EFContext();
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
                using EFContext Context = new EFContext();
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
            catch (DbUpdateException ex) when ((ex.InnerException.InnerException is SqlException && (ex.InnerException.InnerException as SqlException).Number == 2601))
            {
                throw new Exception("Já existe finança com Código idêntico registrada", ex);
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
                using EFContext Context = new EFContext();
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
