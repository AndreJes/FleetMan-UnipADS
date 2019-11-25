using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Classes.Desk;
using Modelo.Classes.Usuarios.Permissoes;

namespace Modelo.Classes.Usuarios
{
    public class UsuarioFunc : Usuario
    {
        [Key]
        public long? UsuarioId { get; set; }
        public long? FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public Permissoes.Permissoes Permissoes { get; set; }
    }
}
