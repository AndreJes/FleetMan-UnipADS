using Modelo.Classes.Auxiliares;
using Modelo.Classes.Desk;
using Modelo.Enums;
using System;
using System.Collections.Generic;
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
        public DateTime DataSaida { get; set; }
        public DateTime? DataChegada { get; set; }
        public int QuantidadePassageiros { get; set; }
        public EstadosDeViagem EstadoDaViagem { get; set; }

        public long? VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }

        public long? MotoristaId { get; set; }
        public Motorista Motorista { get; set; }

        public long? GaragemOrigemId { get; set; }
        public Garagem GaragemOrigem { get; set; }

        public long? GaragemRetornoId { get; set; }
        public Garagem GaragemRetorno { get; set; }
    }
}
