using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Classes.Desk;
using Modelo.Classes.Usuarios.Permissoes;

namespace Modelo.Classes.Usuarios
{
    public class UsuarioFunc : Usuario
    {
        public long? FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public Permissoes.Permissoes Permissoes { get; set; }
    }
}
