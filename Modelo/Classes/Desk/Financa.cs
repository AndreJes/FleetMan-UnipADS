﻿using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Desk
{
    public class Financa
    {
        #region Props principais
        [Key]
        public long? FinancaId { get; set; }
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime? DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public EstadosDePagamento EstadoPagamento { get; set; }
        public TipoDeFinanca Tipo { get; set; }
        #endregion

        #region Props não mapeadas
        [NotMapped]
        public string EstadoPagamentoTxt
        {
            get
            {
                switch (EstadoPagamento)
                {
                    case EstadosDePagamento.PAGO:
                        return "Pago";
                    case EstadosDePagamento.VENCIDO:
                        return "Vencido";
                    case EstadosDePagamento.AGUARDANDO:
                        return "Aguardando";
                    default:
                        return "Pagamento Inválido";
                }
            }
        }

        [NotMapped]
        public string Referente
        {
            get
            {
                int index = 0;
                index = Descricao.IndexOf('/');
                if (index > 0)
                {
                    return Descricao.Substring(0, index).Replace("Referente a:", "");
                }
                return "";
            }
        }

        [NotMapped]
        public string Comentario
        {
            get
            {
                int index = 0;
                index = Descricao.IndexOf('/');
                if (index > 0)
                {
                    return Descricao.Substring(index).Replace("/ Comentário:", "");
                }
                return "";
            }
        }
        #endregion

    }
}
