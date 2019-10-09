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
        private FuncionarioService FuncionariosService = new FuncionarioService();

        public IEnumerable<UsuarioFunc> ObterUsuariosFuncOrdPorId()
        {
            return Context.ObterUsuariosFuncOrdPorId();
        }

        public UsuarioFunc ObterUsuarioFuncPorId(long? id)
        {
            return Context.ObterUsuarioFuncPorId(id);
        }

        public void GravarUsuarioFunc(UsuarioFunc usuario)
        {
            Context.GravarUsuarioFunc(usuario);
        }

        public void RemoverUsuarioFuncPorId(long? id)
        {
            Context.RemoverUsuarioFuncPorId(id);
        }

        /// <summary>
        /// Gera um usuário para o funcionario especificado
        /// </summary>
        /// <param name="funcionario">Funcionario que tera seu usuário gerado</param>
        /// <param name="permissoes">Permissoes do usuário dentro do sistemas</param>
        /// <returns>Retorna um objeto do tipo UsuarioFunc: com login igual ao Email do usuário, e senha igual aos 4 primeiros digitos do RG</returns>
        public UsuarioFunc GerarUsuarioFunc(Funcionario funcionario, Permissoes permissoes)
        {
            UsuarioFunc usuario = new UsuarioFunc();
            usuario.FuncionarioId = FuncionariosService.ObterFuncionarioPorCPF(funcionario.CPF).FuncionarioId;
            usuario.Permissoes = permissoes;
            usuario.Login = funcionario.Email;
            usuario.Senha = funcionario.RG.Substring(0, 4);
            if(usuario.FuncionarioId != null && usuario.Permissoes != null)
            {
                return usuario;
            }
            else
            {
                return null;
            }
        }
    }
}
