using Modelo.Classes.Web;
using Persistencia.DAL.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Web
{
    public class AluguelService
    {
        private AluguelDAL Context = new AluguelDAL();

        public IEnumerable<Aluguel> ObterAlugueisOrdPorId()
        {
            return Context.ObterAlugueisOrdPorId();
        }

        public Aluguel ObterAluguelPorId(long? id)
        {
            return Context.ObterAluguelPorId(id);
        }

        public void GravarAluguel(Aluguel aluguel)
        {
            Context.GravarAluguel(aluguel);
        }

        public void RemoverAluguelPorId(long? id)
        {
            Context.RemoverAluguelPorId(id);
        }
    }
}
