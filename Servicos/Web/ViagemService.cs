using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Classes.Web;
using Persistencia.DAL.Web;

namespace Servicos.Web
{
    public class ViagemService
    {
        private ViagemDAL Context = new Persistencia.DAL.Web.ViagemDAL();

        public IEnumerable<Viagem> ObterViagensOrdPorId()
        {
            return Context.ObterViagensOrdPorId();
        }
    }
}
