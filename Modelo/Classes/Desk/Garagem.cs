using Modelo.Classes.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Desk
{
    public class Garagem
    {
        #region Props principais
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
        #endregion

        #region Props não mapeadas
        [NotMapped]
        public string CNPJTxt
        {
            get
            {
                return CNPJ.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
            }
        }

        [NotMapped]
        public string TelefoneTxt
        {
            get
            {
                return Telefone.Insert(0, "(").Insert(3, ") ").Insert(9, "-");
            }
        }
        #endregion

        public List<Veiculo> Veiculos { get; set; }
    }
}
