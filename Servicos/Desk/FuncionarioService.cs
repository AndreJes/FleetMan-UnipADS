using Modelo.Classes.Desk;
using Persistencia.DAL.Desk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Desk
{
    public class FuncionarioService
    {
        private FuncionarioDAL Context = new FuncionarioDAL();

        public IEnumerable<Funcionario> ObterFuncionariosOrdPorId()
        {
            return Context.ObterFuncionariosOrdPorId();
        }

        public Funcionario ObterFuncionarioPorId(long? id)
        {
            return Context.ObterFuncionarioPorId(id);
        }

        public Funcionario ObterFuncionarioPorCPF(string cpf)
        {
            return Context.ObterFuncionarioPorCPF(cpf);
        }

        public void GravarFuncionario(Funcionario funcionario)
        {
            Context.GravarFuncionario(funcionario);
        }

        public void RemoverFuncionarioPorId(long? id)
        {
            Context.RemoverFuncionarioPorId(id);
        }
    }
}
