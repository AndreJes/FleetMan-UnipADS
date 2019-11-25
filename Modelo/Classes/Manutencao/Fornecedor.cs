using Modelo.Classes.Auxiliares;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Manutencao
{
    public class Fornecedor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public long? FornecedorId { get; set; }
        public string CNPJ { get; set; }
        public string Razao_Social { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public bool LojaVirtual { get; set; }
        public Endereco Endereco { get; set; }

        public virtual ICollection<Peca> Pecas { get; set; }
    }
}
