using Modelo.Classes.Desk;
using Persistencia.DAL.Desk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Desk
{
    public class GaragemService
    {
        private GaragenDAL Context = new GaragenDAL();

        public IEnumerable<Garagem> ObterGaragensOrdPorId()
        {
            return Context.ObterGaragensOrdPorId();
        }

        public void GravarGaragem(Garagem garagem)
        {
            Context.GravarGaragem(garagem);
        }

        public Garagem ObterGaragemPorId(long? id)
        {
            return Context.ObterGaragemPorId(id);
        }

        public void RemoverGaragemPorId(long? id)
        {
            Context.RemoverGaragemPorId(id);
        }
    }
}
