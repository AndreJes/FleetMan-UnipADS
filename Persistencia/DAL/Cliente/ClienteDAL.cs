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
    }
}
