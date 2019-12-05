using Modelo.Classes.Manutencao;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Manutencao
{
    public class FornecedorDAL
    {
        public IEnumerable<Fornecedor> ObterFornecedoresOrdPorId()
        {
            try
            {
                using EFContext Context = new EFContext();
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
                using EFContext Context = new EFContext();
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
                using EFContext Context = new EFContext();
                if (fornecedor.FornecedorId == null)
                {
                    Context.Fornecedores.Add(fornecedor);
                }
                else
                {
                    AttachItem(fornecedor, Context);
                    Context.Entry(fornecedor).State = EntityState.Modified;
                }
                Context.SaveChanges();
            }
            catch (DbUpdateException ex) when ((ex.InnerException.InnerException is SqlException && (ex.InnerException.InnerException as SqlException).Number == 2601))
            {

                throw new Exception("Já existe um fornecedor com CNPJ e/ou Email idêntico(s) registrado", ex);
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
                using EFContext Context = new EFContext();
                Fornecedor fornecedor = ObterFornecedorPorId(id);
                AttachItem(fornecedor, Context);
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
                using EFContext Context = new EFContext();
                return Context.Fornecedores.Where(f => f.CNPJ == cnpj).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AttachItem(Fornecedor fornecedor, EFContext Context)
        {
            if (!Context.Fornecedores.Local.Contains(fornecedor))
            {
                Context.Fornecedores.Attach(fornecedor);
            }
        }
    }
}
