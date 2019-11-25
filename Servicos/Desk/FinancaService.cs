using Modelo.Classes.Desk;
using Persistencia.DAL.Desk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Desk
{
    public class FinancaService
    {
        private FinancaDAL Context = new FinancaDAL();

        public IEnumerable<Financa> ObterFinancasOrdPorId()
        {
            try
            {
                return Context.ObterFinancasOrdPorId();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Financa ObterFinancaPorId(long? id)
        {
            try
            {
                return Context.ObterFinancaPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GravarFinanca(Financa financa)
        {
            try
            {
                if(financa.DataPagamento > DateTime.Now)
                {
                    throw new Exception("Data de pagamento inválida");
                }
                Context.GravarFinanca(financa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RemoverFinancaPorId(long? id)
        {
            try
            {
                Context.RemoverFinancaPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
