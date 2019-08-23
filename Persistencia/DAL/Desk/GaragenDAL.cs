using Modelo.Classes.Desk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Desk
{
    public class GaragenDAL : DALContext
    {
        public IEnumerable<Garagem> ObterGaragensOrdPorId()
        {
            return Context.Garagens.OrderBy(g => g.GaragemId);
        }
    }
}
