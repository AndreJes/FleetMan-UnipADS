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
        public string Local { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public TiposDeManutencao Tipo { get; set; }
        public EstadosDeManutencao EstadoAtual { get; set; }

        public List<long> PecasIds { get; set; }
        public List<Peca> PecasUtilizadas { get; set; }
    }
}
