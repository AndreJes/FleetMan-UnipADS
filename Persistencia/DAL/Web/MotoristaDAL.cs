using Modelo.Classes.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Persistencia.Contexts;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace Persistencia.DAL.Web
{
    public class MotoristaDAL
    {
        public IEnumerable<Motorista> ObterMotoristasOrdPorId()
        {
            try
            {
                using EFContext Context = new EFContext();
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
                using EFContext Context = new EFContext();
                if (motorista.MotoristaId == null)
                {
                    Context.Motoristas.Add(motorista);
                }
                else
                {
                    AttachItem(motorista, Context);
                    Context.Entry(motorista).State = EntityState.Modified;
                }
                Context.SaveChanges();
            }
            catch (DbUpdateException ex) when ((ex.InnerException.InnerException is SqlException && (ex.InnerException.InnerException as SqlException).Number == 2601))
            {
                throw new Exception("Já existe um motorista com CPF, Celular e/ou Email idêntico(s) registrados", ex);
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
                using EFContext Context = new EFContext();
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
                using EFContext Context = new EFContext();
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
                using EFContext Context = new EFContext();
                Motorista motorista = ObterMotoristaPorId(id);
                Context.Motoristas.Remove(motorista);
                AttachItem(motorista, Context);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AttachItem(Motorista motorista, EFContext Context)
        {
            if (!Context.Motoristas.Local.Contains(motorista))
            {
                Context.Motoristas.Attach(motorista);
            }
        }

    }
}
