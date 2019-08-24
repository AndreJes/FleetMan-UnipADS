using Modelo.Classes.Auxiliares;
using Modelo.Classes.Web;
using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Manutencao
{
    public class Manutencao
    {
        public long? ManutencaoId { get; set; }
        public Endereco Local { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public TiposDeManutencao Tipo { get; set; }
        public EstadosDeManutencao EstadoAtual { get; set; }

        public List<Peca> PecasUtilizadas { get; set; }

        public long? VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}
