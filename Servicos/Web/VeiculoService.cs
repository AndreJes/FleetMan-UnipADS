using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Classes.Web;
using Persistencia.DAL.Web;

namespace Servicos.Web
{
    public class VeiculoService
    {
        private VeiculoDAL Context = new VeiculoDAL();

        public IQueryable<Veiculo> ObterVeiculosOrdPorId()
        {
            return Context.ObterVeiculosOrdPorId();
        }

        public void GravarVeiculo(Veiculo veiculo)
        {
            Context.GravarVeiculo(veiculo);
        }
    }
}
