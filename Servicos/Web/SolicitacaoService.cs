using Modelo.Classes.Web;
using Persistencia.DAL.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Web
{
    public class SolicitacaoService
    {
        private SolicitacaoDAL Context = new SolicitacaoDAL();

        public IEnumerable<Solicitacao> ObterSolicitacoesOrdPorId()
        {
            return Context.ObterSolicitacoesOrdPorId();
        }
    }
}
