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
    }
}
