using Modelo.Classes.Desk;
using Modelo.Classes.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWeb.Models.Veiculos
{
    public class VeiculoViewModel
    {
        public Veiculo Veiculo { get; set; }
        
        public IEnumerable<Multa> Multas
        {
            get
            {
                return Veiculo.Multas;
            }
        }

        public IEnumerable<Sinistro> Sinistros
        {
            get
            {
                return Veiculo.Sinistros;
            }
        }
    }
}