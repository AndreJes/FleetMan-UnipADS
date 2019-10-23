using Modelo.Classes.Manutencao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Manutencao
{
    public class AbastecimentoDAL : DALContext
    {
        public IEnumerable<Abastecimento> ObterAbastecimentosOrdPorId()
        {
            return Context.Abastecimentos.OrderBy(a => a.AbastecimentoId).Include(a => a.Motorista).Include(a => a.Veiculo).ToList();
        }

        public Abastecimento ObterAbastecimentoPorId(long? id)
        {
            return Context.Abastecimentos.Where(a => a.AbastecimentoId == id).FirstOrDefault();
        }

        public void GravarAbastecimento(Abastecimento abastecimento)
        {
            if (abastecimento.AbastecimentoId == null)
            {
                Context.Abastecimentos.Add(abastecimento);
            }
            else
            {
                Context.Entry(abastecimento).State = EntityState.Modified;
            }
            Context.SaveChanges();
        }

        public void RemoverAbastecimentoPorId(long? id)
        {
            Abastecimento abastecimento = ObterAbastecimentoPorId(id);
            Context.Abastecimentos.Remove(abastecimento);
            Context.SaveChanges();
        }
    }
}
