using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Manutencao.Associacao
{
    public class PecasManutencao
    {
        [Key, Column(Order = 1)]
        public long? PecaManutencaoId { get; set; }
        [ForeignKey("Peca"), Column(Order = 2), Required]
        public long? PecaId { get; set; }
        [ForeignKey("Manutencao"), Column(Order = 3), Required]
        public long? ManutencaoId { get; set; }

        public virtual Peca Peca { get; set; }
        public virtual Manutencao Manutencao { get; set; }

        public int QuantidadePecasUtilizadas { get; set; }
    }
}
