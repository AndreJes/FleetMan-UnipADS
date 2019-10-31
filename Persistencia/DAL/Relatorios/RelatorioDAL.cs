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

        public Relatorio ObterRelatorioPorId(long? id, TiposRelatorios tipo)
        {
            switch (tipo)
            {
                case TiposRelatorios.VIAGEM:
                    return Context.RelatoriosViagens.Where(rv => rv.RelatorioId == id).FirstOrDefault();
                case TiposRelatorios.MULTA:
                    return Context.RelatoriosMultas.Where(rm => rm.RelatorioId == id).FirstOrDefault();
                case TiposRelatorios.ACIDENTE:
                    return Context.RelatoriosAcidentes.Where(ra => ra.RelatorioId == id).FirstOrDefault();
                case TiposRelatorios.CONSUMO:
                    return Context.RelatoriosConsumos.Where(rc => rc.RelatorioId == id).FirstOrDefault();
                case TiposRelatorios.FINANCEIRO:
                    return Context.RelatoriosFinanceiros.Where(rf => rf.RelatorioId == id).FirstOrDefault();
                case TiposRelatorios.MANUTENCOES:
                    return Context.RelatoriosManutencao.Where(rm => rm.RelatorioId == id).FirstOrDefault();
                default:
                    throw new Exception("Tipo de relatório invalido!");
            }
        }

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
                    throw new Exception("Tipo de relatório invalido!");
            }

            Context.SaveChanges();
        }

        public void RemoverRelatorioPorId(long? id, TiposRelatorios tipo)
        {
            Relatorio relatorio = ObterRelatorioPorId(id, tipo);
            switch (tipo)
            {
                case TiposRelatorios.VIAGEM:
                    Context.RelatoriosViagens.Remove(relatorio as RelatorioViagem);
                    break;
                case TiposRelatorios.MULTA:
                    Context.RelatoriosMultas.Remove(relatorio as RelatorioMulta);
                    break;
                case TiposRelatorios.ACIDENTE:
                    Context.RelatoriosAcidentes.Remove(relatorio as RelatorioSinistros);
                    break;
                case TiposRelatorios.CONSUMO:
                    Context.RelatoriosConsumos.Remove(relatorio as RelatorioConsumo);
                    break;
                case TiposRelatorios.FINANCEIRO:
                    Context.RelatoriosFinanceiros.Remove(relatorio as RelatorioFinanceiro);
                    break;
                case TiposRelatorios.MANUTENCOES:
                    Context.RelatoriosManutencao.Remove(relatorio as RelatorioManutencao);
                    break;
                default:
                    throw new Exception("Tipo de relatório invalido!");
            }

            Context.SaveChanges();
        }
    }
}
