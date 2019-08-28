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
    }
}
