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

        public Veiculo ObterVeiculoPorId(long? id)
        {
            return Context.Veiculos.Where(v => v.VeiculoId == id).Include(v => v.Multas).Include(v => v.Sinistros).Include(v => v.Garagem).Include(v => v.Cliente).Include(v => v.Seguro).First();
        }

        public Veiculo ObterVeiculoPorPlaca(string placa)
        {
            Veiculo veiculo = ObterVeiculosOrdPorId().Where(v => v.Placa == placa).FirstOrDefault();
            return veiculo;
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

        public void RemoverVeiculoPorId(long? id)
        {
            Veiculo veiculo = ObterVeiculoPorId(id);
            Context.Veiculos.Remove(veiculo);
            Context.SaveChanges();
        }
    }
}
