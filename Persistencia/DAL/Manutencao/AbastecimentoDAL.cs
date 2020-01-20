using Modelo.Classes.Manutencao;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Manutencao
{
    public class AbastecimentoDAL
    {
        public IEnumerable<Abastecimento> ObterAbastecimentosOrdPorId()
        {
            using EFContext Context = new EFContext();
            return Context.Abastecimentos.OrderBy(a => a.AbastecimentoId).Include(a => a.Motorista).Include(a => a.Veiculo).ToList();
        }

        public Abastecimento ObterAbastecimentoPorId(long? id)
        {
            using EFContext Context = new EFContext();
            return Context.Abastecimentos.Where(a => a.AbastecimentoId == id).Include(a => a.Motorista).Include(a => a.Veiculo).FirstOrDefault();
        }

        public void GravarAbastecimento(Abastecimento abastecimento)
        {
            using EFContext Context = new EFContext();
            if (abastecimento.AbastecimentoId == null)
            {
                Context.Abastecimentos.Add(abastecimento);
            }
            else
            {
                AttachItem(abastecimento, Context);
                Context.Entry(abastecimento).State = EntityState.Modified;
            }
            Context.SaveChanges();
        }

        public void RemoverAbastecimentoPorId(long? id)
        {
            using EFContext Context = new EFContext();
            Abastecimento abastecimento = ObterAbastecimentoPorId(id);
            AttachItem(abastecimento, Context);
            Context.Abastecimentos.Remove(abastecimento);
            Context.SaveChanges();
        }

        private void AttachItem(Abastecimento abastecimento, EFContext Context)
        {
            if (!Context.Abastecimentos.Local.Contains(abastecimento))
            {
                Context.Abastecimentos.Attach(abastecimento);
            }
        }
    }
}
