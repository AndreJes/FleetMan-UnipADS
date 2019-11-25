using Modelo.Classes.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Persistencia.DAL.Web
{
    public class MotoristaDAL : DALContext
    {
        public IEnumerable<Motorista> ObterMotoristasOrdPorId()
        {
            try
            {
                return Context.Motoristas.OrderBy(m => m.MotoristaId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GravarMotorista(Motorista motorista)
        {
            try
            {
                if (motorista.MotoristaId == null)
                {
                    Context.Motoristas.Add(motorista);
                }
                else
                {
                    Context.Entry(motorista).State = EntityState.Modified;
                }
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Motorista ObterMotoristaPorId(long? id)
        {
            try
            {
                return Context.Motoristas.Where(m => m.MotoristaId == id).Include(m => m.Cliente).Include(m => m.Multas.Select(m => m.Veiculo)).Include(m => m.Sinistros.Select(m => m.Veiculo)).Include(m => m.Viagens).First();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Motorista ObterMotoristaPorCPF(string cpf)
        {
            try
            {
                Motorista motorista = ObterMotoristasOrdPorId().Where(m => m.CPF == cpf).FirstOrDefault();
                return motorista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoverMotoristaPorId(long? id)
        {
            try
            {
                Motorista motorista = ObterMotoristaPorId(id);
                Context.Motoristas.Remove(motorista);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
