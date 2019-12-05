using Modelo.Classes.Desk;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Desk
{
    public class SinistroDAL
    {
        public IEnumerable<Sinistro> ObterSinistrosOrdPorId()
        {
            using EFContext Context = new EFContext();
            return Context.Sinistros.OrderBy(s => s.SinistroId).ToList();
        }

        public Sinistro ObterSinistroPorId(long? id)
        {
            using EFContext Context = new EFContext();
            return Context.Sinistros.Where(s => s.SinistroId == id).Include(s => s.Veiculo).Include(s => s.Motorista).First();
        }

        public void GravarSinistro(Sinistro sinistro)
        {
            try
            {
                using EFContext Context = new EFContext();
                if (sinistro.SinistroId == null)
                {
                    Context.Sinistros.Add(sinistro);
                }
                else
                {
                    Context.Entry(sinistro).State = EntityState.Modified;
                }
                Context.SaveChanges();
            }
            catch (DbUpdateException ex) when ((ex.InnerException.InnerException is SqlException && (ex.InnerException.InnerException as SqlException).Number == 2601))
            {
                throw new Exception("Já existe um sinistro com Código idêntico registrado", ex);
            }
        }

        public void RemoverSinistroPorId(long? id)
        {
            using EFContext Context = new EFContext();
            Sinistro sinistro = ObterSinistroPorId(id);
            Context.Sinistros.Remove(sinistro);
            Context.SaveChanges();
        }
    }
}
