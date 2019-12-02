using Modelo.Classes.Web;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Web
{
    public class AluguelDAL
    {
        public IEnumerable<Aluguel> ObterAlugueisOrdPorId()
        {
            try
            {
                using EFContext Context = new EFContext();
                return Context.Alugueis.Include(a => a.Veiculo).OrderBy(a => a.AluguelId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Aluguel ObterAluguelPorId(long? id)
        {
            try
            {
                using EFContext Context = new EFContext();
                return Context.Alugueis.Where(a => a.AluguelId == id).Include(a => a.Cliente).Include(a => a.Veiculo).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GravarAluguel(Aluguel aluguel)
        {
            try
            {
                using EFContext Context = new EFContext();
                if (aluguel.AluguelId == null)
                {
                    Context.Alugueis.Add(aluguel);
                }
                else
                {
                    AttachItem(aluguel, Context);
                    Context.Entry(aluguel).State = EntityState.Modified;
                }
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoverAluguelPorId(long? id)
        {
            try
            {
                using EFContext Context = new EFContext();
                Aluguel aluguel = ObterAluguelPorId(id);
                AttachItem(aluguel, Context);
                Context.Alugueis.Remove(aluguel);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AttachItem(Aluguel aluguel, EFContext Context)
        {
            if (!Context.Alugueis.Local.Contains(aluguel))
            {
                Context.Alugueis.Attach(aluguel);
            }
        }
    }
}
