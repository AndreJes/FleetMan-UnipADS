using Modelo.Classes.Desk;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Desk
{
    public class FuncionarioDAL
    {
        public IEnumerable<Funcionario> ObterFuncionariosOrdPorId()
        {
            using EFContext Context = new EFContext();
            return Context.Funcionarios.OrderBy(f => f.FuncionarioId).ToList();
        }

        public Funcionario ObterFuncionarioPorId(long? id)
        {
            using EFContext Context = new EFContext();
            return Context.Funcionarios.Where(f => f.FuncionarioId == id).FirstOrDefault();
        }

        public void GravarFuncionario(Funcionario funcionario)
        {
            using EFContext Context = new EFContext();
            if (funcionario.FuncionarioId == null)
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
            using EFContext Context = new EFContext();
            Funcionario funcionario = ObterFuncionarioPorId(id);
            if(funcionario != null)
            {
                Context.Funcionarios.Remove(funcionario);
                Context.SaveChanges();
            }
        }

        public Funcionario ObterFuncionarioPorCPF(string cpf)
        {
            using EFContext Context = new EFContext();
            return Context.Funcionarios.Where(f => f.CPF == cpf).FirstOrDefault();
        }
    }
}
