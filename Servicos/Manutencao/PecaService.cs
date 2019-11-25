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
            try
            {
                return Context.ObterPecasOrdPorId();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Peca ObterPecaPorId(long? id)
        {
            try
            {
                return Context.ObterPecaPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GravarPeca(Peca peca)
        {
            try
            {
                Context.GravarPeca(peca);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RemoverPecaPorId(long? id)
        {
            try
            {
                Context.RemoverPecaPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
