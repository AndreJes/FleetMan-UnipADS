using Modelo.Classes.Manutencao;
using Persistencia.DAL.Manutencao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Manutencao
{
    public class PecaService
    {
        private PecaDAL Context = new PecaDAL();

        public IEnumerable<Peca> ObterPecasOrdPorId()
        {
            return Context.ObterPecasOrdPorId();
        }

        public Peca ObterPecaPorId(long? id)
        {
            return Context.ObterPecaPorId(id);
        }

        public void GravarPeca(Peca peca)
        {
            Context.GravarPeca(peca);
        }

        public void RemoverPecaPorId(long? id)
        {
            Context.RemoverPecaPorId(id);
        }
    }
}
