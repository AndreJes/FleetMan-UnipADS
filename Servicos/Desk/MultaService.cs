using Modelo.Classes.Desk;
using Persistencia.DAL.Desk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Desk
{
    public class MultaService
    {
        private MultaDAL Context = new MultaDAL();

        public IEnumerable<Multa> ObterMultasOrdPorId()
        {
            return Context.ObterMultasOrdPorId();
        }
    }
}
