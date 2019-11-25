using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Classes.Desk;
using Modelo.Enums;

namespace Modelo.Classes.Web
{
    public class Veiculo
    {
        #region Props Principais

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public long? VeiculoId { get; set; }

        public string Nome { get; set; }
        public string Placa { get; set; }
        public int Ano { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string CodRenavam { get; set; }
        public string Cor { get; set; }
        public bool Adaptado { get; set; }
        public bool ParaLocacao { get; set; }
        #endregion
        #region Enums
        public EstadosTanqueCombustivel EstadoDoTanque { get; set; }
        public TiposDeVeiculo Tipo { get; set; }
        public EstadosDeVeiculo EstadoDoVeiculo { get; set; }
        public CategoriasCNH CategoriaExigida { get; set; }
        #endregion
        #region Props não mapeadas
        [NotMapped]
        public string AdaptadoTxt
        {
            get
            {
                return Adaptado ? "Sim" : "Não";
            }
        }
        [NotMapped]
        public string ParaLocacaoTxt
        {
            get
            {
                return ParaLocacao ? "Sim" : "Não";
            }
        }
        [NotMapped]
        public string EstadoTxt
        {
            get
            {
                switch (EstadoDoVeiculo)
                {
                    case EstadosDeVeiculo.NORMAL:
                        return "Normal";
                    case EstadosDeVeiculo.EM_VIAGEM:
                        return "Em viagem";
                    case EstadosDeVeiculo.EM_MANUTENCAO:
                        return "Em manutenção";
                    case EstadosDeVeiculo.SEM_COMBUSTIVEL:
                        return "Sem combustível";
                    case EstadosDeVeiculo.ALUGADO:
                        return "Alugado";
                    case EstadosDeVeiculo.INATIVO:
                        return "Inativo";
                    case EstadosDeVeiculo.ACIDENTADO:
                        return "Acidentado";
                    default:
                        return "Irregular";
                }
            }

        }

        [NotMapped]
        public double EstadoDoTanqueValor
        {
            get
            {
                return (int)EstadoDoTanque;
            }
        }

        #endregion

        //Garagem atual a qual o veiculo pertence.
        public long? GaragemId { get; set; }
        public Garagem Garagem { get; set; }

        //Cliente ao qual o veiculo pertence. Pode ser nulo se Locação for escolhida
        public long? ClienteId { get; set; }
        public Clientes.Cliente Cliente { get; set; }

        //Seguro que cobre o veiculo
        public long? SeguroId { get; set; }
        public Seguro Seguro { get; set; }

        public virtual ICollection<Multa> Multas { get; set; }
        public virtual ICollection<Sinistro> Sinistros { get; set; }
        public virtual ICollection<Manutencao.Manutencao> Manutencoes { get; set; }

    }
}
