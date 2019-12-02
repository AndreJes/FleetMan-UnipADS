using Modelo.Classes.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Persistencia.Contexts;

namespace Persistencia.DAL.Web
{
    public class VeiculoDAL
    {
        public IEnumerable<Veiculo> ObterVeiculosOrdPorId()
        {
            try
            {
                using EFContext Context = new EFContext();
                return Context.Veiculos.OrderBy(v => v.VeiculoId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Veiculo ObterVeiculoPorId(long? id)
        {
            try
            {
                using EFContext Context = new EFContext();
                return Context.Veiculos.Where(v => v.VeiculoId == id).Include(v => v.Multas.Select(m => m.Motorista)).Include(v => v.Sinistros.Select(s => s.Motorista)).Include(v => v.Garagem).Include(v => v.Cliente).Include(v => v.Seguro).Include(v => v.Manutencoes).First();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Veiculo ObterVeiculoPorPlaca(string placa)
        {
            try
            {
                using EFContext Context = new EFContext();
                Veiculo veiculo = ObterVeiculosOrdPorId().Where(v => v.Placa == placa).FirstOrDefault();
                return veiculo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GravarVeiculo(Veiculo veiculo)
        {
            try
            {
                using EFContext Context = new EFContext();
                if (veiculo.VeiculoId == null)
                {
                    Context.Veiculos.Add(veiculo);
                }
                else
                {
                    AttachItem(veiculo, Context);
                    Context.Entry(veiculo).State = EntityState.Modified;
                }
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoverVeiculoPorId(long? id)
        {
            try
            {
                using EFContext Context = new EFContext();
                Veiculo veiculo = ObterVeiculoPorId(id);
                AttachItem(veiculo, Context);
                Context.Veiculos.Remove(veiculo);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AttachItem(Veiculo veiculo, EFContext Context)
        {
            if (!Context.Veiculos.Local.Contains(veiculo))
            {
                Context.Veiculos.Attach(veiculo);
            }
        }
    }
}
