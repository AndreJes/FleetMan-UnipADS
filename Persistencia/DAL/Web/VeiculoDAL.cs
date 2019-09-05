using Modelo.Classes.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Persistencia.DAL.Web
{
    public class VeiculoDAL : DALContext
    {
        public IQueryable<Veiculo> ObterVeiculosOrdPorId()
        {
            return Context.Veiculos.OrderBy(v => v.VeiculoId);
        }

        public void GravarVeiculo(Veiculo veiculo)
        {
            if(veiculo.VeiculoId == null)
            {
                Context.Veiculos.Add(veiculo);
            }
            else
            {
                Context.Entry(veiculo).State = EntityState.Modified;
            }
            Context.SaveChanges();
        }
    }
}
