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
            return Context.UsuariosFuncionarios.OrderBy(u => u.UsuarioId).ToList();
        }

        public UsuarioFunc ObterUsuarioFuncPorId(long? id)
        {
            return Context.UsuariosFuncionarios.Where(u => u.UsuarioId == id).Include(f => f.Funcionario).FirstOrDefault();
        }

        public void GravarUsuarioFunc(UsuarioFunc usuario)
        {
            if (usuario.UsuarioId == null)
            {
                Context.UsuariosFuncionarios.Add(usuario);
            }
            else
            {
                Context.Entry(usuario).State = EntityState.Modified;
            }
            Context.SaveChanges();
        }

        public void RemoverUsuarioFuncPorId(long? id)
        {
            UsuarioFunc usuario = ObterUsuarioFuncPorId(id);
            if(usuario != null)
            {
                Context.UsuariosFuncionarios.Remove(usuario);
                Context.SaveChanges();
            }
        }
    }
}
