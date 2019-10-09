using Modelo.Classes.Desk;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Desk
{
    public class FuncionarioDAL : DALContext
    {
        public IEnumerable<Funcionario> ObterFuncionariosOrdPorId()
        {
            return Context.Funcionarios.OrderBy(f => f.FuncionarioId);
        }

        public Funcionario ObterFuncionarioPorId(long? id)
        {
            return Context.Funcionarios.Where(f => f.FuncionarioId == id).FirstOrDefault();
        }

        public void GravarFuncionario(Funcionario funcionario)
        {
            if(funcionario.FuncionarioId == null)
            {
                Context.Funcionarios.Add(funcionario);
            }
            else
            {
                Context.Entry(funcionario).State = EntityState.Modified;
            }
            Context.SaveChanges();
        }

        public void RemoverFuncionarioPorId(long? id)
        {
            Funcionario funcionario = ObterFuncionarioPorId(id);
            if(funcionario != null)
            {
                Context.Funcionarios.Remove(funcionario);
                Context.SaveChanges();
            }
        }

        public Funcionario ObterFuncionarioPorCPF(string cpf)
        {
            return Context.Funcionarios.Where(f => f.CPF == cpf).FirstOrDefault();
        }
    }
}
