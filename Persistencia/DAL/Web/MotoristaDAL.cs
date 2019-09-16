using Modelo.Classes.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Persistencia.DAL.Web
{
    public class MotoristaDAL : DALContext
    {
        public IEnumerable<Motorista> ObterMotoristasOrdPorId()
        {
            return Context.Motoristas.OrderBy(m => m.MotoristaId);
        }

        public void GravarMotorista(Motorista motorista)
        {
            if(motorista.MotoristaId == null)
            {
                Context.Motoristas.Add(motorista);
            }
            else
            {
                Context.Entry(motorista).State = EntityState.Modified;
            }
            Context.SaveChanges();
        }

        public Motorista ObterMotoristaPorId(long? id)
        {
            return Context.Motoristas.Where(m => m.MotoristaId == id).Include(m => m.Cliente).Include(m => m.Multas).Include(m => m.Sinistros).Include(m => m.Viagens).First();
        }

        public void RemoverMotoristaPorId(long? id)
        {
            Motorista motorista = ObterMotoristaPorId(id);
            Context.Motoristas.Remove(motorista);
            Context.SaveChanges();
        }
    }
}
