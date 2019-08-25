using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Enums;

namespace Modelo.Classes.Web
{
    public class Solicitacao
    {
        public long? SolicitacaoId { get; set; }
        public string ItemSerializado { get; set; }
        public ItemSolicitacao TipoDeItem { get; set; }
        public EstadosDaSolicitacao Estado { get; set; }
        public TiposDeSolicitacao Tipo { get; set; }

        #region Props não mapeadas
        [NotMapped]
        public string TipoDeItemTxt
        {
            get
            {
                switch (TipoDeItem)
                {
                    case ItemSolicitacao.VEICULO:
                        return "Veiculo";
                    case ItemSolicitacao.MOTORISTA:
                        return "Motorista";
                    case ItemSolicitacao.ALUGUEL:
                        return "Aluguel";
                    default:
                        return "Tipo Inválido";
                }
            }
        }
        [NotMapped]
        public string TipoDeSoliciTxt
        {
            get
            {
                switch (Tipo)
                {
                    case TiposDeSolicitacao.INCLUSAO:
                        return "Inclusão";
                    case TiposDeSolicitacao.EXCLUSAO:
                        return "Remoção";
                    case TiposDeSolicitacao.ALTERACAO:
                        return "Alteração";
                    case TiposDeSolicitacao.RENOVACAO_ALUGUEL:
                        return "Renovar locação";
                    case TiposDeSolicitacao.CANCELAMENTO_ALUGUEL:
                        return "Cancelaar locação";
                    default:
                        return "Tipo Inválido";
                }
            }
        }
        #endregion

        public long? ClienteId { get; set; }
        public Clientes.Cliente Cliente { get; set; }
    }
}
