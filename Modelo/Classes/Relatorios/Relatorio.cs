using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Relatorios
{
    public abstract class Relatorio
    {
        public long? RelatorioId { get; set; }
        public DateTime DataEmissao { get; set; }
        public string Descricao { get; set; }
        public TiposRelatorios Tipo { get; set; }
    }
}
