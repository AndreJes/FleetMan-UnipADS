using Modelo.Classes.Desk;
using Persistencia.DAL.Desk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Desk
{
    public class SinistroService
    {
        private SinistroDAL Context = new SinistroDAL();

        public IEnumerable<Sinistro> ObterSinistrosOrdPorId()
        {
            return Context.ObterSinistrosOrdPorId();
        }
    }
}
