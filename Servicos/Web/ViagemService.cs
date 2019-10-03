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

        public Viagem ObterViagemPorId(long? id)
        {
            return Context.ObterViagemPorId(id);
        }

        public void GravarViagem(Viagem viagem)
        {
            Context.GravarViagem(viagem);
        }

        public void RemoverViagemPorId(long? id)
        {
            Context.RemoverViagemPorId(id);
        }
    }
}
