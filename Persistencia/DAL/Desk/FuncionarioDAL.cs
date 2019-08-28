using Modelo.Classes.Desk;
using System;
using System.Collections.Generic;
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
    }
}
