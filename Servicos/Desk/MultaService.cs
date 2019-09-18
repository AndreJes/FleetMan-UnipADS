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

        public Multa ObterMultaPorId(long? id)
        {
            return Context.ObterMultaPorId(id);
        }

        public void GravarMulta(Multa multa)
        {
            Context.GravarMulta(multa);
        }

        public void RemoverMultaPorId(long? id)
        {
            Context.RemoverMultaPorId(id);
        }
    }
}
