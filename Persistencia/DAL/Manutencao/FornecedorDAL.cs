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
            try
            {
                return Context.Fornecedores.OrderBy(f => f.FornecedorId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Fornecedor ObterFornecedorPorId(long? id)
        {
            try
            {
                return Context.Fornecedores.Where(f => f.FornecedorId == id).Include(f => f.Pecas).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GravarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                if (fornecedor.FornecedorId == null)
                {
                    Context.Fornecedores.Add(fornecedor);
                }
                else
                {
                    Context.Entry(fornecedor).State = EntityState.Modified;
                }
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoverFornecedorPorId(long? id)
        {
            try
            {
                Fornecedor fornecedor = ObterFornecedorPorId(id);
                Context.Fornecedores.Remove(fornecedor);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Fornecedor ObterFornecedorPorCNPJ(string cnpj)
        {
            try
            {
                return Context.Fornecedores.Where(f => f.CNPJ == cnpj).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
