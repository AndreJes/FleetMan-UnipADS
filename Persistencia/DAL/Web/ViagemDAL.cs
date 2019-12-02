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
    public class ViagemDAL
    {
        public IEnumerable<Viagem> ObterViagensOrdPorId()
        {
            try
            {
                using EFContext Context = new EFContext();
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
                using EFContext Context = new EFContext();
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
                using EFContext Context = new EFContext();
                if (viagem.ViagemId == null)
                {
                    Context.Viagens.Add(viagem);
                }
                else
                {
                    AttachItem(viagem, Context);
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
                using EFContext Context = new EFContext();
                Viagem viagem = ObterViagemPorId(id);
                AttachItem(viagem, Context);
                Context.Viagens.Remove(viagem);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AttachItem(Viagem viagem, EFContext context)
        {
            if(!context.Viagens.Local.Contains(viagem))
            {
                context.Viagens.Attach(viagem);
            }
        }
    }
}
