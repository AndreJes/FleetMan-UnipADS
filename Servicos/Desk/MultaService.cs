using Modelo.Classes.Desk;
using Persistencia.DAL.Desk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Desk
{
    public class MultaService
    {
        private MultaDAL Context = new MultaDAL();

        public IEnumerable<Multa> ObterMultasOrdPorId()
        {
            try
            {
                return Context.ObterMultasOrdPorId();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Multa ObterMultaPorId(long? id)
        {
            try
            {
                return Context.ObterMultaPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GravarMulta(Multa multa)
        {
            try
            {
                if(multa.DataDaMulta > DateTime.Now)
                {
                    throw new Exception("Data da multa inválida");
                }
                Context.GravarMulta(multa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RemoverMultaPorId(long? id)
        {
            try
            {
                Context.RemoverMultaPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
