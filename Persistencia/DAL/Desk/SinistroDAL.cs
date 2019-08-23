using Modelo.Classes.Desk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Desk
{
    public class SinistroDAL : DALContext
    {
        public IEnumerable<Sinistro> ObterSinistrosOrdPorId()
        {
            return Context.Sinistros.OrderBy(s => s.SinistroId);
        }
    }
}
