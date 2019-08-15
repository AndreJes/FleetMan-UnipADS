using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Enums;

namespace Modelo.Classes.Web
{
    class Solicitacao
    {
        public long? SolicitacaoId { get; set; }
        public object Item { get; set; }
        public ItemSolicitacao TipoDeItem { get; set; }
        public EstadosDaSolicitacao Estado { get; set; }
        public TiposDeSolicitacao Tipo { get; set; }

    }
}
