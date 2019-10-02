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
            return Context.Viagens.Where(v => v.ViagemId == id).FirstOrDefault();
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
    }
}
