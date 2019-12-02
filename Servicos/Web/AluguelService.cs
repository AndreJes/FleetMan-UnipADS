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
    public class AluguelService
    {
        private AluguelDAL Context = new AluguelDAL();
        private VeiculoService VeiculoService = new VeiculoService();

        public IEnumerable<Aluguel> ObterAlugueisOrdPorId()
        {
            try
            {
                return Context.ObterAlugueisOrdPorId();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Aluguel ObterAluguelPorId(long? id)
        {
            try
            {
                return Context.ObterAluguelPorId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GravarAluguel(Aluguel aluguel)
        {
            try
            {
                if(aluguel.EstadoDoAluguel == EstadosAluguel.REGULAR)
                {
                    Veiculo veiculo = VeiculoService.ObterVeiculoPorId(aluguel.VeiculoId);
                    veiculo.EstadoDoVeiculo = EstadosDeVeiculo.ALUGADO;
                    veiculo.ClienteId = aluguel.ClienteId;
                    VeiculoService.GravarVeiculo(veiculo);
                }
                if(aluguel.EstadoDoAluguel == EstadosAluguel.CANCELADO)
                {
                    Veiculo veiculo = VeiculoService.ObterVeiculoPorId(aluguel.VeiculoId);
                    veiculo.EstadoDoVeiculo = EstadosDeVeiculo.NORMAL;
                    veiculo.ClienteId = null;
                    VeiculoService.GravarVeiculo(veiculo);
                }
                Context.GravarAluguel(aluguel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoverAluguelPorId(long? id)
        {
            try
            {
                Aluguel aluguel = ObterAluguelPorId(id);
                if (!(aluguel.EstadoDoAluguel == EstadosAluguel.CANCELADO))
                {
                    throw new Exception("Aluguel precisa ser cancelado antes de ser removido");
                }
                Context.RemoverAluguelPorId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
