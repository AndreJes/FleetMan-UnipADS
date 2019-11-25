using Modelo.Classes.Desk;
using Persistencia.DAL.Desk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Desk
{
    public class SinistroService
    {
        private SinistroDAL Context = new SinistroDAL();

        public IEnumerable<Sinistro> ObterSinistrosOrdPorId()
        {
            try
            {
                return Context.ObterSinistrosOrdPorId();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Sinistro ObterSinistroPorId(long? id)
        {
            try
            {
                return Context.ObterSinistroPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GravarSinistro(Sinistro sinistro)
        {
            try
            {
                if (sinistro.DataSinistro > DateTime.Now)
                {
                    throw new Exception("Data do sinistro inválida");
                }
                Context.GravarSinistro(sinistro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RemoverSinistroPorId(long? id)
        {
            try
            {
                Context.RemoverSinistroPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
