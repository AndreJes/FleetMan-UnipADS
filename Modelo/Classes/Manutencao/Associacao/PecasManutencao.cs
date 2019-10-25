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
        public long? PecaId { get; set; }
        [Key, Column(Order = 2)]
        public long? ManutencaoId { get; set; }

        public Peca Peca { get; set; }
        public Manutencao Manutencao { get; set; }

        public int QuantidadePecasUtilizadas { get; set; }
    }
}
