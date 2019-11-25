using Modelo.Classes.Desk;
using Persistencia.DAL.Desk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Desk
{
    public class GaragemService
    {
        private GaragenDAL Context = new GaragenDAL();

        public IEnumerable<Garagem> ObterGaragensOrdPorId()
        {
            try
            {
                return Context.ObterGaragensOrdPorId();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GravarGaragem(Garagem garagem)
        {
            try
            {
                Context.GravarGaragem(garagem);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Garagem ObterGaragemPorId(long? id)
        {
            try
            {
                return Context.ObterGaragemPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RemoverGaragemPorId(long? id)
        {
            try
            {
                Garagem garagem = ObterGaragemPorId(id);
                if(garagem.Veiculos.Count > 0 )
                {
                    throw new Exception("Não é possivel remover garagens que possuem veiculos");
                }
                Context.RemoverGaragemPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
