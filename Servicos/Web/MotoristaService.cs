using Modelo.Classes.Web;
using Persistencia.DAL.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Web
{
    public class MotoristaService
    {
        private MotoristaDAL Context = new MotoristaDAL();

        public IEnumerable<Motorista> ObterMotoristasOrdPorId()
        {
            return Context.ObterMotoristasOrdPorId();
        }

        public void GravarMotorista(Motorista motorista)
        {
            Context.GravarMotorista(motorista);
        }

        public Motorista ObterMotoristaPorId(long? id)
        {
            return Context.ObterMotoristaPorId(id);
        }

        public void RemoverMotoristaPorId(long? id)
        {
            Context.RemoverMotoristaPorId(id);
        }
    }
}
