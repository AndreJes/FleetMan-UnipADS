using Modelo.Classes.Desk;
using Modelo.Classes.Manutencao;
using Modelo.Classes.Relatorios;
using Modelo.Classes.Web;
using Modelo.Enums;
using Persistencia.DAL.Desk;
using Persistencia.DAL.Manutencao;
using Persistencia.DAL.Relatorios;
using Persistencia.DAL.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Relatorios
{
    public class RelatorioService
    {
        private RelatorioDAL Context = new RelatorioDAL();
        private ManutencaoDAL ManutencaoContext = new ManutencaoDAL();
        private MultaDAL MultaContext = new MultaDAL();
        private SinistroDAL SinistroContext = new SinistroDAL();
        private ViagemDAL ViagemContext = new ViagemDAL();
        private FinancaDAL FinancaContext = new FinancaDAL();
        private AbastecimentoDAL AbastecimentoContext = new AbastecimentoDAL();

        #region Obter relatórios por tipo
        public IEnumerable<Relatorio> ObterRelatoriosAcidenteOrdPorId()
        {
            return Context.ObterRelatoriosAcidenteOrdPorId();
        }

        public IEnumerable<RelatorioConsumo> ObterRelatoriosConsumoOrdPorId()
        {
            return Context.ObterRelatoriosConsumoOrdPorId();
        }

        public IEnumerable<RelatorioFinanceiro> ObterRelatoriosFinanceiroOrdPorId()
        {
            return Context.ObterRelatoriosFinanceiroOrdPorId();
        }

        public IEnumerable<RelatorioManutencao> ObterRelatoriosManutencaoOrdPorId()
        {
            return Context.ObterRelatoriosManutencaoOrdPorId();
        }

        public IEnumerable<RelatorioMulta> ObterRelatoriosMultaOrdPorId()
        {
            return Context.ObterRelatoriosMultaOrdPorId();
        }

        public IEnumerable<RelatorioViagem> ObterRelatoriosViagemOrdPorId()
        {
            return Context.ObterRelatoriosViagemOrdPorId();
        }
        #endregion

        public Relatorio GerarRelatorio(DateTime dataInicio, DateTime dataFinal, TiposRelatorios tipo, string descricao = "")
        {
            switch (tipo)
            {
                case TiposRelatorios.VIAGEM:
                    List<Viagem> viagens = ViagemContext.ObterViagensOrdPorId()
                        .Where(v => v.DataSaida >= dataInicio)
                        .Where(v => v.DataChegada <= dataFinal)
                        .ToList();

                    RelatorioViagem relatorioViagem = new RelatorioViagem(dataInicio, dataFinal, tipo, viagens, descricao: descricao);

                    return relatorioViagem;

                case TiposRelatorios.MULTA:
                    List<Multa> multas = MultaContext.ObterMultasOrdPorId()
                        .Where(m => m.DataDaMulta >= dataInicio)
                        .Where(m => m.DataDaMulta <= dataFinal)
                        .ToList();

                    RelatorioMulta relatorioMulta = new RelatorioMulta(dataInicio, dataFinal, tipo, multas, descricao: descricao);

                    return relatorioMulta;

                case TiposRelatorios.ACIDENTE:
                    List<Sinistro> sinistros = SinistroContext.ObterSinistrosOrdPorId()
                        .Where(s => s.DataSinistro >= dataInicio)
                        .Where(s => s.DataSinistro <= dataFinal)
                        .ToList();

                    RelatorioSinistros relatorioSinistros = new RelatorioSinistros(dataInicio, dataFinal, tipo, sinistros, descricao: descricao);

                    return relatorioSinistros;

                case TiposRelatorios.CONSUMO:
                    List<Abastecimento> abastecimentos = AbastecimentoContext.ObterAbastecimentosOrdPorId()
                        .Where(a => a.DataAgendada >= dataInicio || a.DataConclusao >= dataInicio)
                        .Where(a => a.DataAgendada <= dataFinal || a.DataConclusao <= dataFinal)
                        .ToList();

                    RelatorioConsumo relatorioConsumo = new RelatorioConsumo(dataInicio, dataFinal, tipo, abastecimentos, descricao: descricao);

                    return relatorioConsumo;

                case TiposRelatorios.FINANCEIRO:
                    List<Financa> financas = FinancaContext.ObterFinancasOrdPorId()
                        .Where(f => f.DataVencimento >= dataInicio)
                        .Where(f => f.DataVencimento <= dataFinal)
                        .ToList();

                    RelatorioFinanceiro relatorioFinanceiro = new RelatorioFinanceiro(dataInicio, dataFinal, tipo, financas, descricao: descricao);

                    return relatorioFinanceiro;
                case TiposRelatorios.MANUTENCOES:
                    List<Modelo.Classes.Manutencao.Manutencao> manutencoes = ManutencaoContext.ObterManutencoesOrdPorId()
                        .Where(m => m.DataEntrada >= dataInicio)
                        .Where(m => m.DataSaida <= dataFinal)
                        .ToList();

                    RelatorioManutencao relatorioManutencao = new RelatorioManutencao(dataInicio, dataFinal, tipo, manutencoes, descricao: descricao);

                    return relatorioManutencao;
                default:
                    throw new Exception("Tipo de relatório inválido");
            }
        }

        public void GravarRelatorio(Relatorio relatorio, TiposRelatorios tipo)
        {
            Context.GravarRelatorio(relatorio, tipo);
        }
    }
}
