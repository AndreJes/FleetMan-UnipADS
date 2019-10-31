using Modelo.Classes.Web;
using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Relatorios
{
    public abstract class Relatorio
    {
        [Key]
        public long? RelatorioId { get; set; }
        
        public string Descricao { get; set; }

        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }

        public DateTime DataEmissao { get; set; }

        public TiposRelatorios Tipo { get; set; }

        public Relatorio(DateTime dataInicio, DateTime dataFinal, TiposRelatorios tipo, string descricao = "") 
        {
            DataInicial = dataInicio;
            DataFinal = dataFinal;
            Tipo = tipo;
            Descricao = descricao;
        }
    }
}
