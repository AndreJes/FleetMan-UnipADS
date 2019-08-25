using Modelo.Classes.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Web
{
    public class ViagemDAL : DALContext
    {
        public IEnumerable<Viagem> ObterViagensOrdPorId()
        {
            return Context.Viagens.OrderBy(v => v.ViagemId);
        }
    }
}
