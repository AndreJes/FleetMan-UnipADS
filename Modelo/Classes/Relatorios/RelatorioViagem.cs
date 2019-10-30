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
        public int QntTotalViagens { get; set; }

        public int QntViagensAguardando { get; set; }
        public int QntViagensEmAndamento { get; set; }
        public int QntViagensConcluidas{ get; set; }
        public int QntViagensCanceladas { get; set; }
    }
}
