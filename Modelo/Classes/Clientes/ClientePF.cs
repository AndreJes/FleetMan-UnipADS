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
    public class ClientePF : Cliente
    {
        [StringLength(11)]
        [Index(IsUnique = true)]
        public string CPF { get; set; }

        [NotMapped]
        [JsonIgnore]
        public string CPFTxt
        {
            get
            {
                return CPF.Insert(3, ".").Insert(7, ".").Insert(11, "-");
            }
        }
    }
}
