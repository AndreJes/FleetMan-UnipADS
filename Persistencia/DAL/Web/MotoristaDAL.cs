using Modelo.Classes.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Web
{
    public class MotoristaDAL : DALContext
    {
        public IEnumerable<Motorista> ObterMotoristasOrdPorId()
        {
            return Context.Motoristas.OrderBy(m => m.MotoristaId);
        }
    }
}
