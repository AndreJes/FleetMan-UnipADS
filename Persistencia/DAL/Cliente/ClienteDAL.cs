using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Classes.Clientes;

namespace Persistencia.DAL.Cliente
{
    public class ClienteDAL : DALContext
    {
        public IEnumerable<Modelo.Classes.Clientes.Cliente> ObterTodosOsClientesOrdPorId()
        {
            IList<Modelo.Classes.Clientes.Cliente> Clientes = new List<Modelo.Classes.Clientes.Cliente>();

            foreach (ClientePF pf in Context.ClientesPF.ToList())
            {
                Clientes.Add(pf);
            }
            foreach (ClientePJ pj in Context.ClientesPJ.ToList())
            {
                Clientes.Add(pj);
            }

            return Clientes;
        }

        public void RegistrarCliente(Modelo.Classes.Clientes.Cliente cliente)
        {
            if(cliente is ClientePF)
            {
                if(cliente.ClienteId == null)
                {
                    Context.ClientesPF.Add(cliente as ClientePF);
                }
                else
                {
                    Context.Entry(cliente).State = EntityState.Modified;
                }
            }
            else
            {
                if (cliente.ClienteId == null)
                {
                    Context.ClientesPJ.Add(cliente as ClientePJ);
                }
                else
                {
                    Context.Entry(cliente).State = EntityState.Modified;
                }
            }
            Context.SaveChanges();
        }

        public ClientePF ObterClientePFPorId(long? id)
        {
          return Context.ClientesPF.Where(c => c.ClienteId == id).Include(c => c.Veiculos).Include(c => c.Motoristas).Include(c => c.Alugueis).FirstOrDefault();
        }

        public ClientePJ ObterClientePJPorId(long? id)
        {
            return Context.ClientesPJ.Where(c => c.ClienteId == id).Include(c => c.Veiculos).Include(c => c.Alugueis).Include(c => c.Motoristas).FirstOrDefault();
        }

        public void RemoverCliente(Modelo.Classes.Clientes.Cliente cliente)
        {
            Context.Clientes.Remove(cliente);
            Context.SaveChanges();
        }
    }
}
