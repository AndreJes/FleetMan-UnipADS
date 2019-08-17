using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Classes.Desk;
using Modelo.Enums;

namespace Modelo.Classes.Web
{
    public class Veiculo
    {
        public long? VeiculoId { get; set; }
        public string Nome { get; set; }
        public string Placa { get; set; }
        public ushort Ano { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string CodRenavam { get; set; }
        public string Cor { get; set; }
        public bool Adaptado { get; set; }
        public bool Paralocacao { get; set; }
        public EstadosTanqueCombustivel EstadoDoTanque { get; set; }
        public TiposDeVeiculo Tipo { get; set; }
        public EstadosDeVeiculo EstadoDoVeiculo { get; set; }
        public CategoriasCNH CategoriaExigida { get; set; }

        //Garagem atual a qual o veiculo pertence.
        public long? GaragemId { get; set; }
        public Garagem Garagem { get; set; }

        public long? ClienteId { get; set; }
        public Clientes.Cliente Cliente { get; set; }

        public List<Multa> Multas { get; set; }
        public List<Sinistro> Sinistros { get; set; }
        public List<Manutencao.Manutencao> Manutencoes { get; set; }

    }
}
