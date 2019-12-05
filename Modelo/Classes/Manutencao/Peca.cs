using Modelo.Classes.Manutencao.Associacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Manutencao
{
    public class Peca
    {
        [Key]
        public long? PecaId { get; set; }
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Lote { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }

        [Required]
        public long? FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }

        public virtual ICollection<PecasManutencao> Manutencoes { get; set; }
    }
}
