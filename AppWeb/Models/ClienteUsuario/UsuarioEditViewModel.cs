using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppWeb.Models.ClienteUsuario
{
    public class UsuarioEditViewModel
    {
        [Required]
        public string EmailAtual { get; set; }
        public string NovoEmail { get; set; }

        [Required]
        public string SenhaAtual { get; set; }
        public string NovaSenha { get; set; }
    }
}