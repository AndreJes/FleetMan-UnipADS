using Modelo.Classes.Usuarios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Usuarios
{
    public class UsuariosFuncDAL : DALContext
    {
        public IEnumerable<UsuarioFunc> ObterUsuariosFuncOrdPorId()
        {
            return Context.UsuariosFuncionarios.OrderBy(u => u.FuncionarioId).ToList();
        }

        public UsuarioFunc ObterUsuarioFuncPorId(long? id)
        {
            return Context.UsuariosFuncionarios.Where(u => u.FuncionarioId == id).Include(f => f.Funcionario).FirstOrDefault();
        }

        public UsuarioFunc ObterUsuarioFuncPorEmail(string email)
        {
            return Context.UsuariosFuncionarios.Where(u => u.Login.Equals(email)).Include(f => f.Funcionario).FirstOrDefault();
        }

        public void GravarUsuarioFunc(UsuarioFunc usuario)
        {
            Context.UsuariosFuncionarios.Add(usuario);
            Context.SaveChanges();
        }

        public void AlterarUsuarioFunc(UsuarioFunc usuario)
        {
            Context.Entry(usuario).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void RemoverUsuarioFuncPorId(long? id)
        {
            UsuarioFunc usuario = ObterUsuarioFuncPorId(id);
            if (usuario != null)
            {
                Context.UsuariosFuncionarios.Remove(usuario);
                Context.SaveChanges();
            }
        }
    }
}
