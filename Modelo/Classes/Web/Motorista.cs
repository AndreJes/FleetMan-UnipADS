using Modelo.Classes.Desk;
using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Web
{
    public class Motorista
    {
        public long? MotoristaId { get; set; }
        public string NumeroCNH { get; set; }
        public int PontosCNH { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public bool MotoristaProprio { get; set; }
        public DateTime VencimentoExame { get; set; }
        public EstadosDeMotorista Estado { get; set; }

        public long? ClienteId { get; set; }
        public Clientes.Cliente Cliente { get; set; }

        public List<Multa> Multas { get; set; }
        public List<Sinistro> Sinistros { get; set; }
        public List<Viagem> Viagens { get; set; }

    }
}
