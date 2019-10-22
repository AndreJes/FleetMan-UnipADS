using Modelo.Classes.Manutencao;
using Persistencia.DAL.Manutencao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Manutencao
{
    public class FornecedorService
    {
        private FornecedorDAL Context = new FornecedorDAL();

        public IEnumerable<Fornecedor> ObterFornecedoresOrdPorId()
        {
            return Context.ObterFornecedoresOrdPorId();
        }

        public Fornecedor ObterFornecedorPorId(long? id)
        {
            return Context.ObterFornecedorPorId(id);
        }

        public void GravarFornecedor(Fornecedor fornecedor)
        {
            Context.GravarFornecedor(fornecedor);
        }

        public void RemoverFornecedorPorId(long? id)
        {
            Context.RemoverFornecedorPorId(id);
        }
    }
}
