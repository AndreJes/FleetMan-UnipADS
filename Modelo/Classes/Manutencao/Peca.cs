using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Manutencao
{
    public class Peca
    {
        public long? PecaId { get; set; }
        public string Lote { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }

        public long? FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
