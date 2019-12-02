using Modelo.Classes.Desk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Persistencia.Contexts;

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
            using EFContext Context = new EFContext();
            if (seguro.SeguroId == null)
            {
                Context.Seguro.Add(seguro);
            }
            else
            {
                Context.Entry(seguro).State = EntityState.Modified;
            }
            Context.SaveChanges();
        }

        public Seguro ObterSeguroPorId(long? id)
        {
            using EFContext Context = new EFContext();
            return Context.Seguro.Where(s => s.SeguroId == id).FirstOrDefault();
        }

        public void RemoverSeguroPorId(long? id)
        {
            using EFContext Context = new EFContext();
            Seguro seguro = ObterSeguroPorId(id);
            Context.Seguro.Remove(seguro);
            Context.SaveChanges();
        }
    }
}
