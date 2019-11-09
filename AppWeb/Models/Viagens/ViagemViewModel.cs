using Modelo.Classes.Web;
using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWeb.Models.Viagens
{
    public class ViagemViewModel
    {
        public IEnumerable<Viagem> Viagens { private get; set; }

        public IEnumerable<Viagem> ViagensAguardando
        {
            get
            {
                return Viagens.Where(v => v.EstadoDaViagem == EstadosDeViagem.AGUARDANDO_INICIO);
            }
        }

        public IEnumerable<Viagem> ViagensEmAndamento
        {
            get
            {
                return Viagens.Where(v => v.EstadoDaViagem == EstadosDeViagem.EM_ANDAMENTO);
            }
        }

        public IEnumerable<Viagem> ViagensConcluidas
        {
            get
            {
                return Viagens.Where(v => v.EstadoDaViagem == EstadosDeViagem.CONCLUIDA);
            }
        }

        public IEnumerable<Viagem> ViagensCanceladas
        {
            get
            {
                return Viagens.Where(v => v.EstadoDaViagem == EstadosDeViagem.CANCELADA);
            }
        }
    }
}