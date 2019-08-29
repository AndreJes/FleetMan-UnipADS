using Modelo.Classes.Auxiliares;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Clientes
{
    public class ClientePF : Cliente
    {
        public string CPF { get; set; }

        [NotMapped]
        public string CPFTxt
        {
            get
            {
                return CPF.Insert(3, ".").Insert(7, ".").Insert(11, "-");
            }
        }
    }
}
