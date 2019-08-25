using Modelo.Classes.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Web
{
    public class AluguelDAL : DALContext
    {
        public IEnumerable<Aluguel> ObterAlugueisOrdPorId()
        {
            return Context.Alugueis.OrderBy(a => a.AluguelId);
        }
    }
}
