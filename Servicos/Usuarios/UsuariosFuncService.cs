using Modelo.Classes.Desk;
using Modelo.Classes.Usuarios;
using Modelo.Classes.Usuarios.Permissoes;
using Persistencia.DAL.Usuarios;
using Servicos.Desk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Usuarios
{
    public class UsuariosFuncService
    {
        private UsuariosFuncDAL Context = new UsuariosFuncDAL();

        public IEnumerable<UsuarioFunc> ObterUsuariosFuncOrdPorId()
        {
            return Context.ObterUsuariosFuncOrdPorId();
        }

        public UsuarioFunc ObterUsuarioFuncPorId(long? id)
        {
            return Context.ObterUsuarioFuncPorId(id);
        }

        public UsuarioFunc ObterUsuarioFuncPorEmail(string email)
        {
            return Context.ObterUsuarioFuncPorEmail(email);
        }

        public void GravarUsuarioFunc(UsuarioFunc usuario)
        {
            Context.GravarUsuarioFunc(usuario);
        }

        public void AlterarUsuarioFunc(UsuarioFunc usuario)
        {
            Context.AlterarUsuarioFunc(usuario);
        }

        public void RemoverUsuarioFuncPorId(long? id)
        {
            Context.RemoverUsuarioFuncPorId(id);
        }
    }
}
