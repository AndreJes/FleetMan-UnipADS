using Modelo.Classes.Usuarios;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Usuarios
{
    public class UsuariosFuncDAL
    {
        public IEnumerable<UsuarioFunc> ObterUsuariosFuncOrdPorId()
        {
            using EFContext Context = new EFContext();
            return Context.UsuariosFuncionarios.OrderBy(u => u.FuncionarioId).ToList();
        }

        public UsuarioFunc ObterUsuarioFuncPorId(long? id)
        {
            using EFContext Context = new EFContext();
            return Context.UsuariosFuncionarios.Where(u => u.FuncionarioId == id).Include(f => f.Funcionario).First();
        }

        public UsuarioFunc ObterUsuarioFuncPorEmail(string email)
        {
            using EFContext Context = new EFContext();
            return Context.UsuariosFuncionarios.Where(u => u.Login == email).Include(f => f.Funcionario).First();
        }

        public void GravarUsuarioFunc(UsuarioFunc usuario)
        {
            using EFContext Context = new EFContext();
            Context.UsuariosFuncionarios.Add(usuario);
            Context.SaveChanges();
        }

        public void AlterarUsuarioFunc(UsuarioFunc usuario)
        {
            using EFContext Context = new EFContext();
            AttachItem(usuario, Context);
            Context.Entry(usuario).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void RemoverUsuarioFuncPorId(long? id)
        {
            using EFContext Context = new EFContext();
            UsuarioFunc usuario = ObterUsuarioFuncPorId(id);
            if (usuario != null)
            {
                AttachItem(usuario, Context);
                Context.UsuariosFuncionarios.Remove(usuario);
                Context.SaveChanges();
            }
        }

        private void AttachItem(UsuarioFunc usuario, EFContext Context)
        {
            if (!Context.UsuariosFuncionarios.Local.Contains(usuario))
            {
                Context.UsuariosFuncionarios.Attach(usuario);
            }
        }
    }
}
