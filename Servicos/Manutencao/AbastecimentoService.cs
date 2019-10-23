using Modelo.Classes.Manutencao;
using Persistencia.DAL.Manutencao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Manutencao
{
    public class AbastecimentoService
    {
        private AbastecimentoDAL Context = new AbastecimentoDAL();

        public IEnumerable<Abastecimento> ObterAbastecimentosOrdPorId()
        {
            return Context.ObterAbastecimentosOrdPorId();
        }

        public Abastecimento ObterAbastecimentoPorId(long? id)
        {
            return Context.ObterAbastecimentoPorId(id);
        }

        public void GravarAbastecimento(Abastecimento abastecimento)
        {
            Context.GravarAbastecimento(abastecimento);
        }

        public void RemoverAbastecimentoPorId(long? id)
        {
            Context.RemoverAbastecimentoPorId(id);
        }
    }
}
