using Modelo.Classes.Web;
using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWeb.Models.Alugueis
{
    public class AluguelViewModel
    {
        public IEnumerable<Aluguel> Alugueis { private get; set; }

        public IEnumerable<Aluguel> AlugueisRegulares
        {
            get
            {
                return Alugueis.Where(a => a.EstadoDoAluguel == EstadosAluguel.REGULAR);
            }
        }

        public IEnumerable<Aluguel> AlugueisVencidos
        {
            get
            {
                return Alugueis.Where(a => a.EstadoDoAluguel == EstadosAluguel.VENCIDO);
            }
        }

        public IEnumerable<Aluguel> AlugueisCancelados
        {
            get
            {
                return Alugueis.Where(a => a.EstadoDoAluguel == EstadosAluguel.CANCELADO);
            }
        }

    }
}