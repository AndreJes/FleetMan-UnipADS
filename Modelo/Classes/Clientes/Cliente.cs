using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Clientes
{
    public abstract class Cliente
    {
        public long? ClienteId { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }

        public Cliente()
        {
            Ativo = true;
        }

        public Cliente(long clienteId, string telefone, string endereco, string nome, string email) : this()
        {
            ClienteId = clienteId;
            Telefone = telefone;
            Endereco = endereco;
            Nome = nome;
            Email = email;
        }
    }
}
