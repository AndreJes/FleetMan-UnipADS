using Modelo.Classes.Manutencao;
using Modelo.Classes.Manutencao.Associacao;
using Modelo.Classes.Web;
using Modelo.Enums;
using Servicos.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Manutencao
{
    public class ManutencaoService
    {
        private Persistencia.DAL.Manutencao.ManutencaoDAL Context = new Persistencia.DAL.Manutencao.ManutencaoDAL();
        private VeiculoService VeiculoService = new VeiculoService();

        public IEnumerable<Modelo.Classes.Manutencao.Manutencao> ObterManutencoesOrdPorId()
        {
            try
            {
                return Context.ObterManutencoesOrdPorId();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Modelo.Classes.Manutencao.Manutencao ObterManutencaoPorId(long? id)
        {
            try
            {
                return Context.ObterManutencaoPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AdicionarManutencao(Modelo.Classes.Manutencao.Manutencao manutencao, IList<PecasManutencao> pecas)
        {
            try
            {
                if (ValidarManutencao(manutencao))
                {
                    if (manutencao.DataEntrada <= DateTime.Now)
                    {
                        Veiculo veiculo = VeiculoService.ObterVeiculoPorId(manutencao.VeiculoId);
                        veiculo.EstadoDoVeiculo = EstadosDeVeiculo.EM_MANUTENCAO;
                        VeiculoService.GravarVeiculo(veiculo);
                    }
                    Context.AdicionarManutencao(manutencao, pecas);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AlterarManutencao(Modelo.Classes.Manutencao.Manutencao manutencao, IList<PecasManutencao> pecas)
        {
            try
            {
                if (ValidarManutencao(manutencao))
                {
                    if (manutencao.EstadoAtual == EstadosDeManutencao.CONCLUIDA)
                    {
                        Veiculo veiculo = VeiculoService.ObterVeiculoPorId(manutencao.VeiculoId);
                        veiculo.EstadoDoVeiculo = EstadosDeVeiculo.NORMAL;
                        VeiculoService.GravarVeiculo(veiculo);
                    }
                    Context.AlterarManutencao(manutencao, pecas);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RemoverManutencaoPorId(long? id)
        {
            try
            {
                Modelo.Classes.Manutencao.Manutencao manutencao = ObterManutencaoPorId(id);
                Veiculo veiculo = VeiculoService.ObterVeiculoPorId(manutencao.VeiculoId);
                veiculo.EstadoDoVeiculo = EstadosDeVeiculo.NORMAL;
                VeiculoService.GravarVeiculo(veiculo);

                Context.RemoverManutencaoPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool ValidarManutencao(Modelo.Classes.Manutencao.Manutencao manutencao)
        {
            if (manutencao.DataSaida.HasValue && manutencao.DataSaida.Value > DateTime.Now)
            {
                throw new Exception("Data de conclusão inválida");
            }
            else
            {
                return true;
            }
        }
    }
}
