using Modelo.Classes.Desk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Persistencia.DAL.Desk
{
    public class SeguroDAL : DALContext
    {
        public IEnumerable<Seguro> ObterSegurosOrdPorId()
        {
            return Context.Seguro.OrderBy(s => s.SeguroId);
        }

        public void GravarSeguro(Seguro seguro)
        {
            if(seguro.SeguroId == null)
            {
                Context.Seguro.Add(seguro);
            }
            else
            {
                Context.Entry(seguro).State = EntityState.Modified;
            }
            Context.SaveChanges();
        }
    }
}
