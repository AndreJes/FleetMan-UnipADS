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
    public class VeiculoService
    {
        private VeiculoDAL Context = new VeiculoDAL();

        public IEnumerable<Veiculo> ObterVeiculosOrdPorId()
        {
            try
            {
                return Context.ObterVeiculosOrdPorId();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Veiculo ObterVeiculoPorId(long? id)
        {
            try
            {
                return Context.ObterVeiculoPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Veiculo ObterVeiculoPorPlaca(string placa)
        {
            try
            {
                return Context.ObterVeiculoPorPlaca(placa);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GravarVeiculo(Veiculo veiculo)
        {
            try
            {
                Context.GravarVeiculo(veiculo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RemoverVeiculoPorId(long? id)
        {
            try
            {
                Veiculo veiculo = ObterVeiculoPorId(id);
                if (veiculo.EstadoDoVeiculo == EstadosDeVeiculo.ALUGADO)
                {
                    throw new Exception("Veiculo se encontra alugado no momento");
                }
                if (veiculo.EstadoDoVeiculo == EstadosDeVeiculo.EM_VIAGEM)
                {
                    throw new Exception("Veiculo se encontra em viagem no momento");
                }
                Context.RemoverVeiculoPorId(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
