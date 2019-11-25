using Modelo.Classes.Manutencao.Associacao;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Manutencao
{
    public class ManutencaoDAL : DALContext
    {
        public IEnumerable<Modelo.Classes.Manutencao.Manutencao> ObterManutencoesOrdPorId()
        {
            try
            {
                return Context.Manutencoes.OrderBy(m => m.ManutencaoId).Include(m => m.Veiculo).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Modelo.Classes.Manutencao.Manutencao ObterManutencaoPorId(long? id)
        {
            try
            {
                return Context.Manutencoes.Where(m => m.ManutencaoId == id).Include(m => m.Veiculo).Include(m => m.PecasUtilizadas.Select(pu => pu.Peca)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AdicionarManutencao(Modelo.Classes.Manutencao.Manutencao manutencao, IList<PecasManutencao> pecas)
        {
            try
            {
                manutencao.PecasUtilizadas = new ObservableCollection<PecasManutencao>();

                Context.Manutencoes.Add(manutencao);

                Context.SaveChanges();

                AdicionarPecaManutencao(manutencao, pecas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarManutencao(Modelo.Classes.Manutencao.Manutencao manutencao, IList<PecasManutencao> pecas)
        {
            try
            {
                var item = Context.Entry(manutencao);

                item.State = EntityState.Modified;

                item.Collection(m => m.PecasUtilizadas).Load();

                manutencao.PecasUtilizadas.Clear();

                foreach (PecasManutencao p in pecas)
                {
                    PecasManutencao PecaPRemover = Context.PecasManutencao.Where(pm => pm.PecaManutencaoId == p.PecaManutencaoId).FirstOrDefault();
                    PecasManutencao PecaPAdicionar = new PecasManutencao();
                    if (PecaPRemover != null)
                    {
                        PecaPAdicionar.ManutencaoId = PecaPRemover.ManutencaoId;
                        PecaPAdicionar.PecaId = PecaPRemover.PecaId;
                        PecaPAdicionar.QuantidadePecasUtilizadas = PecaPRemover.QuantidadePecasUtilizadas;
                        Context.PecasManutencao.Remove(PecaPRemover);
                        Context.PecasManutencao.Add(PecaPAdicionar);
                    }
                    else
                    {
                        p.Peca = null;
                        p.Manutencao = null;
                        p.ManutencaoId = manutencao.ManutencaoId;
                        Context.PecasManutencao.Add(p);
                    }
                }
                Context.SaveChanges();
                RemoverValoresNulos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoverManutencaoPorId(long? id)
        {
            try
            {
                Modelo.Classes.Manutencao.Manutencao manutencao = ObterManutencaoPorId(id);
                Context.PecasManutencao.RemoveRange(Context.PecasManutencao.Where(pm => pm.ManutencaoId == manutencao.ManutencaoId));
                Context.Manutencoes.Remove(manutencao);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AdicionarPecaManutencao(Modelo.Classes.Manutencao.Manutencao manutencao, IList<PecasManutencao> pecas)
        {
            try
            {
                foreach (PecasManutencao pm in pecas)
                {
                    pm.Peca = null;
                    pm.Manutencao = null;
                    manutencao.PecasUtilizadas.Add(pm);
                }
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RemoverValoresNulos()
        {
            Context.PecasManutencao.RemoveRange(Context.PecasManutencao.Where(pm => pm.ManutencaoId == null));

            Context.SaveChanges();
        }
    }
}
