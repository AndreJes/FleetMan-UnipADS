using Modelo.Classes.Auxiliares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Manutencao
{
    public class Fornecedor
    {
        public long? FornecedorId { get; set; }
        public string CNPJ { get; set; }
        public string Razao_Social { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public bool LojaVirtual { get; set; }
        public Endereco Endereco { get; set; }

        public List<Peca> Pecas { get; set; }
    }
}
