using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Web
{
    class Motorista
    {
        public long? MotoristaId { get; set; }
        public string NumeroCNH { get; set; }
        public int PontosCNH { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime VencimentoExame { get; set; }
        public EstadosDeMotorista Estado { get; set; }

    }
}
