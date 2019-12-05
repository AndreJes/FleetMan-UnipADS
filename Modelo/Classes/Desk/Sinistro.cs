using Modelo.Classes.Web;
using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Desk
{
    public class Sinistro
    {
        [Key]
        public long? SinistroId { get; set; }
        [StringLength(40)]
        [Index(IsUnique = true)]
        public string CodSinistro { get; set; }
        public string Descricao { get; set; }
        public int QntEnvolvidos { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime DataSinistro { get; set; }
        public EstadosDePagamento EstadoPagamento { get; set; }
        public GravidadesDeSinistro Gravidade { get; set; }

        [Required]
        public long? VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }

        [Required]
        public long? MotoristaId { get; set; }
        public Motorista Motorista { get; set; }
    }
}
