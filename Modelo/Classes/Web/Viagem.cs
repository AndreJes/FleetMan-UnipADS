using Modelo.Classes.Auxiliares;
using Modelo.Classes.Desk;
using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Web
{
    public class Viagem
    {
        public long? ViagemId { get; set; }
        public Endereco EnderecoOrigem { get; set; }
        public Endereco EnderecoDestino { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd/MM/yyyy HH:mm}")]
        public DateTime DataSaida { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd/MM/yyyy HH:mm}")]
        public DateTime? DataChegada { get; set; }

        public int QuantidadePassageiros { get; set; }
        public EstadosDeViagem EstadoDaViagem { get; set; }

        [Required]
        public long? VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }

        [Required]
        public long? MotoristaId { get; set; }
        public Motorista Motorista { get; set; }

        public long? GaragemOrigem_GaragemId { get; set; }
        [ForeignKey("GaragemOrigem_GaragemId")]
        public Garagem GaragemOrigem { get; set; }

        public long? GaragemRetorno_GaragemId { get; set; }
        [ForeignKey("GaragemRetorno_GaragemId")]
        public Garagem GaragemRetorno { get; set; }
    }
}
