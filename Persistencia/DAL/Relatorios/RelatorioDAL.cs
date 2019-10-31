using Modelo.Classes.Relatorios;
using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Relatorios
{
    public class RelatorioDAL : DALContext
    {
        #region Obter relatórios por tipo
        public IEnumerable<Relatorio> ObterRelatoriosAcidenteOrdPorId()
        {
            return Context.RelatoriosAcidentes.OrderBy(ra => ra.RelatorioId);
        }

        public IEnumerable<RelatorioConsumo> ObterRelatoriosConsumoOrdPorId()
        {
            return Context.RelatoriosConsumos.OrderBy(rc => rc.RelatorioId);
        }

        public IEnumerable<RelatorioFinanceiro> ObterRelatoriosFinanceiroOrdPorId()
        {
            return Context.RelatoriosFinanceiros.OrderBy(ra => ra.RelatorioId);
        }

        public IEnumerable<RelatorioManutencao> ObterRelatoriosManutencaoOrdPorId()
        {
            return Context.RelatoriosManutencao.OrderBy(rm => rm.RelatorioId);
        }

        public IEnumerable<RelatorioMulta> ObterRelatoriosMultaOrdPorId()
        {
            return Context.RelatoriosMultas.OrderBy(rm => rm.RelatorioId);
        }

        public IEnumerable<RelatorioViagem> ObterRelatoriosViagemOrdPorId()
        {
            return Context.RelatoriosViagens.OrderBy(rv => rv.RelatorioId);
        }
        #endregion

        public void GravarRelatorio(Relatorio relatorio, TiposRelatorios tipo)
        {
            switch (tipo)
            {
                case TiposRelatorios.VIAGEM:
                    Context.RelatoriosViagens.Add(relatorio as RelatorioViagem);
                    break;
                case TiposRelatorios.MULTA:
                    Context.RelatoriosMultas.Add(relatorio as RelatorioMulta);
                    break;
                case TiposRelatorios.ACIDENTE:
                    Context.RelatoriosAcidentes.Add(relatorio as RelatorioSinistros);
                    break;
                case TiposRelatorios.CONSUMO:
                    Context.RelatoriosConsumos.Add(relatorio as RelatorioConsumo);
                    break;
                case TiposRelatorios.FINANCEIRO:
                    Context.RelatoriosFinanceiros.Add(relatorio as RelatorioFinanceiro);
                    break;
                case TiposRelatorios.MANUTENCOES:
                    Context.RelatoriosManutencao.Add(relatorio as RelatorioManutencao);
                    break;
                default:
                    break;
            }

            Context.SaveChanges();
        }
    }
}
