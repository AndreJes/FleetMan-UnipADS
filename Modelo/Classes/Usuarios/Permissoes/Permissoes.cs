using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Usuarios.Permissoes
{
    public class Permissoes
    {
        public bool Veiculos { get; set; }
        public bool Motoristas { get; set; }
        public bool Clientes { get; set; }
        public bool Funcionarios { get; set; }
        public bool Garagens { get; set; }
        public bool Seguros { get; set; }
        public bool Financeiro { get; set; }
        public bool Manutencoes { get; set; }
        public bool MultasSinistros { get; set; }
        public bool Solicitacoes { get; set; }
        public bool Relatorios { get; set; }
        public bool Locacoes { get; set; }
    }
}
