using Modelo.Classes.Auxiliares;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [JsonIgnore]
        public string CNPJTxt
        {
            get
            {
                return CNPJ.FormatarCNPJ();
            }
        }
    }
}
