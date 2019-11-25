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
    public class Multa
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public long? MultaId { get; set; }
        public string CodigoMulta { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:F2}")]
        public double Valor { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime DataDaMulta { get; set; }
        public EstadosDePagamento EstadoDoPagamento { get; set; }
        public GravidadesDeInfracao GravidadeDaInfracao { get; set; }

        [Required]
        public long? VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }

        [Required]
        public long? MotoristaId { get; set; }
        public Motorista Motorista { get; set; }
    }
}
