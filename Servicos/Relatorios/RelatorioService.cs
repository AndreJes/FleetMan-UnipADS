using Modelo.Classes.Relatorios;
using Persistencia.DAL.Relatorios;
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

    }
}
