using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Usuarios.Permissoes
{
    public class Funcoes
    {
        public bool Alterar { get; set; }
        public bool Consultar { get; set; }
        public bool Cadastrar { get; set; }
        public bool Remover { get; set; }
    }
}
