using Modelo.Classes.Web;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Web
{
    public class ViagemDAL : DALContext
    {
        public IEnumerable<Viagem> ObterViagensOrdPorId()
        {
            try
            {
                return Context.Viagens.Include(v => v.Veiculo).Include(v => v.Motorista).OrderBy(v => v.ViagemId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Viagem ObterViagemPorId(long? id)
        {
            try
            {
                return Context.Viagens.Where(v => v.ViagemId == id).Include(v => v.Veiculo).Include(v => v.Motorista).Include(v => v.GaragemOrigem).Include(v => v.GaragemRetorno).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GravarViagem(Viagem viagem)
        {
            try
            {
                if (viagem.ViagemId == null)
                {
                    Context.Viagens.Add(viagem);
                }
                else
                {
                    Context.Entry(viagem).State = EntityState.Modified;
                }
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoverViagemPorId(long? id)
        {
            try
            {
                Viagem viagem = ObterViagemPorId(id);
                Context.Viagens.Remove(viagem);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
