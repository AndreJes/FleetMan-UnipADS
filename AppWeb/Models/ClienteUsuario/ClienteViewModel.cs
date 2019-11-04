using Modelo.Classes.Auxiliares;
using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppWeb.Models.ClienteUsuario
{
    public abstract class ClienteViewModel
    {
        [Required]
        public long? ClienteId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public Endereco Endereco { get; set; }

        public TipoCliente Tipo { get; set; }
    }
}