using Modelo.Classes.Manutencao.Associacao;
using System;
using System.Collections.Generic;
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
            return Context.Manutencoes.OrderBy(m => m.ManutencaoId).ToList();
        }

        public Modelo.Classes.Manutencao.Manutencao ObterManutencaoPorId(long? id)
        {
            return Context.Manutencoes.Where(m => m.ManutencaoId == id).Include(m => m.PecasUtilizadas).FirstOrDefault();
        }

        public void AdicionarManutencao(Modelo.Classes.Manutencao.Manutencao manutencao, IList<Modelo.Classes.Manutencao.Peca> pecas)
        {
            Context.Manutencoes.Add(manutencao);

            manutencao.PecasUtilizadas = new List<PecasManutencao>();

            foreach (Modelo.Classes.Manutencao.Peca p in pecas)
            {
                PecasManutencao pecasManutencao = new PecasManutencao();
                pecasManutencao.PecaId = p.PecaId;
                pecasManutencao.QuantidadePecasUtilizadas = p.Quantidade;
                manutencao.PecasUtilizadas.Add(pecasManutencao);
            }

            Context.SaveChanges();
        }

        public void AlterarManutencao(Modelo.Classes.Manutencao.Manutencao manutencao)
        {
            Context.Entry(manutencao).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void RemoverManutencaoPorId(long? id)
        {
            Modelo.Classes.Manutencao.Manutencao manutencao = ObterManutencaoPorId(id);
            Context.Manutencoes.Remove(manutencao);
            Context.SaveChanges();
        }
    }
}
