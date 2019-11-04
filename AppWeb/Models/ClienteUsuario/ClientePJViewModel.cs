using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppWeb.Models.ClienteUsuario
{
    public class ClientePJViewModel : ClienteViewModel
    {
        [Required]
        public string CNPJ { get; set; }
    }
}