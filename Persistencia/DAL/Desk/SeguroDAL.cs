using Modelo.Classes.Desk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Persistencia.Contexts;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace Persistencia.DAL.Desk
{
    public class SeguroDAL
    {
        public IEnumerable<Seguro> ObterSegurosOrdPorId()
        {
            using EFContext Context = new EFContext();
            return Context.Seguro.OrderBy(s => s.SeguroId).ToList();
        }

        public void GravarSeguro(Seguro seguro)
        {
            try
            {
                using EFContext Context = new EFContext();
                if (seguro.SeguroId == null)
                {
                    Context.Seguro.Add(seguro);
                }
                else
                {
                    AttachItem(seguro, Context);
                    Context.Entry(seguro).State = EntityState.Modified;
                }
                Context.SaveChanges();
            }

            catch (DbUpdateException ex) when ((ex.InnerException.InnerException is SqlException && (ex.InnerException.InnerException as SqlException).Number == 2601))
            {
                throw new Exception("Já existe seguradora com CNPJ e/ou Email idêntico(s) registrada", ex);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Seguro ObterSeguroPorId(long? id)
        {
            using EFContext Context = new EFContext();
            return Context.Seguro.Where(s => s.SeguroId == id).Include(v => v.Veiculos).First();
        }

        public void RemoverSeguroPorId(long? id)
        {
            using EFContext Context = new EFContext();
            Seguro seguro = ObterSeguroPorId(id);
            AttachItem(seguro, Context);
            Context.Seguro.Remove(seguro);
            Context.SaveChanges();
        }

        private void AttachItem(Seguro seguro, EFContext context)
        {
            if (!context.Seguro.Local.Contains(seguro))
            {
                context.Seguro.Attach(seguro);
            }
        }
    }
}
