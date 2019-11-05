using Modelo.Classes.Clientes;
using Modelo.Enums;
using Persistencia.DAL.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Cliente
{
    public class ClienteService
    {
        private ClienteDAL Context = new ClienteDAL();

        public IEnumerable<Modelo.Classes.Clientes.Cliente> ObterClientesOrdPorId()
        {
            return Context.ObterTodosOsClientesOrdPorId();
        }

        public void GravarCliente(Modelo.Classes.Clientes.Cliente cliente)
        {
            Context.GravarCliente(cliente);
        }

        public ClientePF ObterClientePFPorId(long? id)
        {
            return Context.ObterClientePFPorId(id);
        }

        public ClientePJ ObterClientePJPorId(long? id)
        {
            return Context.ObterClientePJPorId(id);
        }

        public Modelo.Classes.Clientes.Cliente ObterClientePorCPFCNPJ(string cpfcnpj, TipoCliente tipo)
        {
            return Context.ObterClientePorCPFCNPJ(cpfcnpj, tipo);
        }

        public Modelo.Classes.Clientes.Cliente ObterClientePorEmailTipo(string email, TipoCliente tipo)
        {
            switch (tipo)
            {
                case TipoCliente.PF:
                    return ObterClientesOrdPorId().Where(c => c.Tipo == TipoCliente.PF).Where(c => c.Email == email).FirstOrDefault();
                case TipoCliente.PJ:
                    return ObterClientesOrdPorId().Where(c => c.Tipo == TipoCliente.PJ).Where(c => c.Email == email).FirstOrDefault();
                default:
                    throw new Exception("Tipo cliente inválido!");
            }
        }

        public void RemoverClientePorId(long? id)
        {
            Context.RemoverClientePorId(id);
        }
    }
}
