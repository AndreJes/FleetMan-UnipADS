using Modelo.Classes.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Desk
{
    public class Garagem
    {
        public long? GaragemId { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string CNPJ { get; set; }
        public ushort Capacidade { get; set; }
        public ushort QuantidadeDeVeiculosNaGaragem
        {
            get
            {
                return Convert.ToUInt16(Veiculos.Count);
            }
        }

        public List<Veiculo> Veiculos { get; set; }
    }
}
