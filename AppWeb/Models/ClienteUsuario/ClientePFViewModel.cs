using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppWeb.Models.ClienteUsuario
{
    public class ClientePFViewModel : ClienteViewModel
    {
        [Required]
        public string CPF { get; set; }
    }
}