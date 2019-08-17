using Modelo.Classes.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Manutencao
{
    public class Abastecimento : Manutencao
    {
        public double QuantidadeAbastecida { get; set; }
        public double Valor { get; set; }

        public long? MotoristaId { get; set; }
        public Motorista Motorista { get; set; }
    }
}
