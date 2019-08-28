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
    }
}
