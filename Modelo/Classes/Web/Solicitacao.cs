using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Enums;

namespace Modelo.Classes.Web
{
    public class Solicitacao
    {
        public long? SolicitacaoId { get; set; }
        public string ItemSerializado { get; set; }
        public ItemSolicitacao TipoDeItem { get; set; }
        public EstadosDaSolicitacao Estado { get; set; }
        public TiposDeSolicitacao Tipo { get; set; }

        public long? ClienteId { get; set; }
        public Clientes.Cliente Cliente { get; set; }
    }
}
