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
        public string UsuarioId { get; set; }

        [Display(Name = "e-Mail Atual")]
        public string EmailAntigo { get; set; }

        [Display(Name = "Novo e-Mail")]
        public string NovoEmail { get; set; }

        [Required(ErrorMessage = "É necessário informar a senha atual!")]
        [Display(Name = "Senha Atual")]
        public string SenhaAtual { get; set; }

        [Display(Name = "Nova Senha")]
        public string NovaSenha { get; set; }
    }
}