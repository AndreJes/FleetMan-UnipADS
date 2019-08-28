using Modelo.Classes.Auxiliares;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Clientes
{
    public class ClientePJ : Cliente
    {
        public string CNPJ { get; set; }

        [NotMapped]
        public string CNPJTxt
        {
            get
            {
                return CNPJ.FormatarCNPJ();
            }
        }

        public ClientePJ() { }

        public ClientePJ(long clienteId, string telefone, Endereco endereco, string nome, string email, string cnpj) : base(clienteId, telefone, endereco, nome, email)
        {
            CNPJ = cnpj;
        }
    }
}
