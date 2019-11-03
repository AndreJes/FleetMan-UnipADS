using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppWeb.Models
{
    public class UsuarioViewModel
    {
        public long? ClienteId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }

        public TipoCliente Tipo { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string CNPJ { get; set; }
    }
}