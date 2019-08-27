using Modelo.Classes.Desk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Desk
{
    public class FinancaDAL : DALContext
    {
        public IEnumerable<Financa> ObterFinancasOrdPorId()
        {
            return Context.Financas.OrderBy(f => f.FinancaId);
        }
    }
}
