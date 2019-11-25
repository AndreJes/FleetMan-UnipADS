using Modelo.Classes.Manutencao.Associacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Manutencao
{
    public class Peca
    {
        public long? PecaId { get; set; }
        public string Lote { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }

        [Required]
        public long? FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }

        public virtual ICollection<PecasManutencao> Manutencoes { get; set; }
    }
}
