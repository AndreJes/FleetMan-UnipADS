using Modelo.Classes.Web;
using Modelo.Enums;
using Persistencia.DAL.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Web
{
    public class MotoristaService
    {
        private MotoristaDAL Context = new MotoristaDAL();

        public IEnumerable<Motorista> ObterMotoristasOrdPorId()
        {
            try
            {
                return Context.ObterMotoristasOrdPorId();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GravarMotorista(Motorista motorista)
        {
            try
            {
                Context.GravarMotorista(motorista);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Motorista ObterMotoristaPorId(long? id)
        {
            try
            {
                return Context.ObterMotoristaPorId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Motorista ObterMotoristaPorCPF(string cpf)
        {
            try
            {
                return Context.ObterMotoristaPorCPF(cpf);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void RemoverMotoristaPorId(long? id)
        {
            try
            {
                bool confirm = await Task.Run(() =>
                {
                    Motorista motorista = ObterMotoristaPorId(id);
                    if (motorista.Estado == EstadosDeMotorista.EM_VIAGEM)
                    {
                        throw new Exception("Motorista se encontra em viagem");
                    }
                    return true;
                });
                if (confirm)
                {
                    Context.RemoverMotoristaPorId(id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
