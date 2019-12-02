using Modelo.Classes.Relatorios;
using Modelo.Enums;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Relatorios
{
    public class RelatorioDAL
    {
        #region Obter relatórios por tipo
        public IEnumerable<Relatorio> ObterRelatoriosAcidenteOrdPorId()
        {
            using EFContext Context = new EFContext();
            return Context.RelatoriosAcidentes.OrderBy(ra => ra.RelatorioId).ToList();
        }

        public IEnumerable<RelatorioConsumo> ObterRelatoriosConsumoOrdPorId()
        {
            using EFContext Context = new EFContext();
            return Context.RelatoriosConsumos.OrderBy(rc => rc.RelatorioId).ToList();
        }

        public IEnumerable<RelatorioFinanceiro> ObterRelatoriosFinanceiroOrdPorId()
        {
            using EFContext Context = new EFContext();
            return Context.RelatoriosFinanceiros.OrderBy(ra => ra.RelatorioId).ToList();
        }

        public IEnumerable<RelatorioManutencao> ObterRelatoriosManutencaoOrdPorId()
        {
            using EFContext Context = new EFContext();
            return Context.RelatoriosManutencao.OrderBy(rm => rm.RelatorioId).ToList();
        }

        public IEnumerable<RelatorioMulta> ObterRelatoriosMultaOrdPorId()
        {
            using EFContext Context = new EFContext();
            return Context.RelatoriosMultas.OrderBy(rm => rm.RelatorioId).ToList();
        }

        public IEnumerable<RelatorioViagem> ObterRelatoriosViagemOrdPorId()
        {
            using EFContext Context = new EFContext();
            return Context.RelatoriosViagens.OrderBy(rv => rv.RelatorioId).ToList();
        }
        #endregion

        public Relatorio ObterRelatorioPorId(long? id, TiposRelatorios tipo)
        {
            using EFContext Context = new EFContext();
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
            using EFContext Context = new EFContext();
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
            using EFContext Context = new EFContext();
            Relatorio relatorio = ObterRelatorioPorId(id, tipo);
            AttachItem(relatorio, Context, tipo);
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

        private void AttachItem(Relatorio relatorio, EFContext Context, TiposRelatorios tipo)
        {
            switch (tipo)
            {
                case TiposRelatorios.VIAGEM:
                    if(!Context.RelatoriosViagens.Local.Contains(relatorio))
                    {
                        Context.RelatoriosViagens.Attach(relatorio as RelatorioViagem);
                    }
                    break;
                case TiposRelatorios.MULTA:
                    if (!Context.RelatoriosMultas.Local.Contains(relatorio))
                    {
                        Context.RelatoriosMultas.Attach(relatorio as RelatorioMulta);
                    }
                    break;
                case TiposRelatorios.ACIDENTE:
                    if (!Context.RelatoriosAcidentes.Local.Contains(relatorio))
                    {
                        Context.RelatoriosAcidentes.Attach(relatorio as RelatorioSinistros);
                    }
                    break;
                case TiposRelatorios.CONSUMO:
                    if (!Context.RelatoriosConsumos.Local.Contains(relatorio))
                    {
                        Context.RelatoriosConsumos.Attach(relatorio as RelatorioConsumo);
                    }
                    break;
                case TiposRelatorios.FINANCEIRO:
                    if (!Context.RelatoriosFinanceiros.Local.Contains(relatorio))
                    {
                        Context.RelatoriosFinanceiros.Attach(relatorio as RelatorioFinanceiro);
                    }
                    break;
                case TiposRelatorios.MANUTENCOES:
                    if (!Context.RelatoriosManutencao.Local.Contains(relatorio))
                    {
                        Context.RelatoriosManutencao.Attach(relatorio as RelatorioManutencao);
                    }
                    break;
            }
        }
    }
}
