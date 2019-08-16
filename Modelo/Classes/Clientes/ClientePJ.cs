using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Clientes
{
    public class ClientePJ : Cliente
    {
        public string CNPJ { get; set; }

        public ClientePJ() { }

        public ClientePJ(long clienteId, string telefone, string endereco, string nome, string email, string cnpj) : base(clienteId, telefone, endereco, nome, email)
        {
            CNPJ = cnpj;
        }
    }
}
