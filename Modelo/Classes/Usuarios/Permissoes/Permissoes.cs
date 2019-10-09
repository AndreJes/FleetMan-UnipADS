using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Usuarios.Permissoes
{
    [ComplexType]
    public class Permissoes
    {
        public Funcoes Veiculos { get; set; }
        public Funcoes Motoristas { get; set; }
        public Funcoes Clientes { get; set; }
        public Funcoes Funcionarios { get; set; }
        public Funcoes Garagens { get; set; }
        public Funcoes Seguros { get; set; }
        public Funcoes Financeiro { get; set; }
        public Funcoes Manutencoes { get; set; }
        public Funcoes MultasSinistros { get; set; }
        public Funcoes Solicitacoes { get; set; }
        public Funcoes Relatorios { get; set; }
        public Funcoes Locacoes { get; set; }
        public Funcoes Viagens { get; set; }
    }
}
