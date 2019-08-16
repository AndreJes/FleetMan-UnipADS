using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Clientes
{
    public class ClientePF : Cliente
    {
        public string CPF { get; set; }

        public ClientePF() { }

        public ClientePF(long clienteId, string telefone, string endereco, string nome, string email, string cPF) : base(clienteId, telefone, endereco, nome, email)
        {
            CPF = cPF;
        }
    }
}
