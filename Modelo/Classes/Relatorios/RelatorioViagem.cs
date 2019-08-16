using Modelo.Classes.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Relatorios
{
    public class RelatorioViagem : Relatorio
    {
        public List<Viagem> Viagens { get; set; }
    }
}
