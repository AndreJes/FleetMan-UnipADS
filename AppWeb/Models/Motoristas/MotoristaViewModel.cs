using Modelo.Classes.Desk;
using Modelo.Classes.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWeb.Models.Motoristas
{
    public class MotoristaViewModel
    {
        public Motorista Motorista { get; set; }

        public IEnumerable<Multa> Multas 
        { 
            get
            {
                return Motorista.Multas;
            }
        }

        public IEnumerable<Sinistro> Sinistros
        {
            get
            {
                return Motorista.Sinistros;
            }
        }
    }
}