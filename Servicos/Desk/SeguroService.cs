using Modelo.Classes.Desk;
using Persistencia.DAL.Desk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Desk
{
    public class SeguroService
    {
        private SeguroDAL Context = new SeguroDAL();

        public IEnumerable<Seguro> ObterSegurosOrdPorId()
        {
            return Context.ObterSegurosOrdPorId();
        }

        public void GravarSeguro(Seguro seguro)
        {
            Context.GravarSeguro(seguro);
        }

        public Seguro ObterSeguroPorId(long? id)
        {
            return Context.ObterSeguroPorId(id);
        }

        public void RemoverSeguroPorId(long? id)
        {
            Context.RemoverSeguroPorId(id);
        }
    }
}
