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
            return Context.Viagens.OrderBy(v => v.ViagemId);
        }

        public Viagem ObterViagemPorId(long? id)
        {
            return Context.Viagens.Where(v => v.ViagemId == id).Include(v => v.Veiculo).Include(v => v.Motorista).Include(v => v.GaragemOrigem).Include(v => v.GaragemRetorno).FirstOrDefault();
        }

        public void GravarViagem(Viagem viagem)
        {
            if(viagem.ViagemId == null)
            {
                Context.Viagens.Add(viagem);
            }
            else
            {
                Context.Entry(viagem).State = EntityState.Modified;
            }
            Context.SaveChanges();
        }

        public void RemoverViagemPorId(long? id)
        {
            Viagem viagem = ObterViagemPorId(id);
            Context.Viagens.Remove(viagem);
            Context.SaveChanges();
        }
    }
}
