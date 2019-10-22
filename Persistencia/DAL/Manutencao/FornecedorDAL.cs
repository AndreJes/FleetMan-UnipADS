using Modelo.Classes.Manutencao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Manutencao
{
    public class FornecedorDAL : DALContext
    {
        public IEnumerable<Fornecedor> ObterFornecedoresOrdPorId()
        {
            return Context.Fornecedores.OrderBy(f => f.FornecedorId).ToList();
        }

        public Fornecedor ObterFornecedorPorId(long? id)
        {
            return Context.Fornecedores.Where(f => f.FornecedorId == id).Include(f => f.Pecas).FirstOrDefault();
        }

        public void GravarFornecedor(Fornecedor fornecedor)
        {
            if(fornecedor.FornecedorId == null)
            {
                Context.Fornecedores.Add(fornecedor);
            }
            else
            {
                Context.Entry(fornecedor).State = EntityState.Modified;
            }
            Context.SaveChanges();
        }

        public void RemoverFornecedorPorId(long? id)
        {
            Fornecedor fornecedor = ObterFornecedorPorId(id);
            Context.Fornecedores.Remove(fornecedor);
            Context.SaveChanges();
        }

        public Fornecedor ObterFornecedorPorCNPJ(string cnpj)
        {
            return Context.Fornecedores.Where(f => f.CNPJ == cnpj).FirstOrDefault();
        }
    }
}
