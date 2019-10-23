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

        public IEnumerable<Veiculo> ObterVeiculosOrdPorId()
        {
            return Context.ObterVeiculosOrdPorId();
        }

        public Veiculo ObterVeiculoPorId(long? id)
        {
            return Context.ObterVeiculoPorId(id);
        }

        public Veiculo ObterVeiculoPorPlaca(string placa)
        {
            return Context.ObterVeiculoPorPlaca(placa);
        }

        public void GravarVeiculo(Veiculo veiculo)
        {
            Context.GravarVeiculo(veiculo);
        }

        public void RemoverVeiculoPorId(long? id)
        {
            Context.RemoverVeiculoPorId(id);
        }
    }
}
