using Modelo.Classes.Desk;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Desk
{
    public class SinistroDAL : DALContext
    {
        public IEnumerable<Sinistro> ObterSinistrosOrdPorId()
        {
            return Context.Sinistros.OrderBy(s => s.SinistroId);
        }

        public Sinistro ObterSinistroPorId(long? id)
        {
            return Context.Sinistros.Where(s => s.SinistroId == id).Include(s => s.Veiculo).Include(s => s.Motorista).First();
        }

        public void GravarSinistro(Sinistro sinistro)
        {
            if(sinistro.SinistroId == null)
            {
                Context.Sinistros.Add(sinistro);
            }
            else
            {
                Context.Entry(sinistro).State = EntityState.Modified;
            }
            Context.SaveChanges();
        }

        public void RemoverSinistroPorId(long? id)
        {
            Sinistro sinistro = ObterSinistroPorId(id);
            Context.Sinistros.Remove(sinistro);
            Context.SaveChanges();
        }
    }
}
