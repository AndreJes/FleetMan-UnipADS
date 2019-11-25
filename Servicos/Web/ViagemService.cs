using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Classes.Web;
using Modelo.Enums;
using Persistencia.DAL.Web;

namespace Servicos.Web
{
    public class ViagemService
    {
        private ViagemDAL Context = new Persistencia.DAL.Web.ViagemDAL();

        public IEnumerable<Viagem> ObterViagensOrdPorId()
        {
            try
            {
                return Context.ObterViagensOrdPorId();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Viagem ObterViagemPorId(long? id)
        {
            try
            {
                return Context.ObterViagemPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GravarViagem(Viagem viagem)
        {
            try
            {
                Context.GravarViagem(viagem);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RemoverViagemPorId(long? id)
        {
            try
            {
                Viagem viagem = ObterViagemPorId(id);
                if(viagem.EstadoDaViagem == EstadosDeViagem.EM_ANDAMENTO)
                {
                    throw new Exception("Não é possivel remover viagens em andamento");
                }
                Context.RemoverViagemPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
