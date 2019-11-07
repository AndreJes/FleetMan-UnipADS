using Modelo.Classes.Clientes;
using Modelo.Classes.Web;
using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace AppWeb.Models.Solicitacoes
{
    public class SolicitacaoViewModel
    {
        public Solicitacao Solicitacao { get; set; }
        public Cliente Cliente
        {
            get
            {
                if (Solicitacao.TipoDeItem == ItemSolicitacao.CLIENTE)
                {
                    if (Solicitacao.ItemSerializado.Contains("CPF"))
                    {
                        return JsonConvert.DeserializeObject<ClientePF>(Solicitacao.ItemSerializado);
                    }
                    else if (Solicitacao.ItemSerializado.Contains("CNPJ"))
                    {
                        return JsonConvert.DeserializeObject<ClientePJ>(Solicitacao.ItemSerializado);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }
        public Aluguel Aluguel
        {
            get
            {
                if (Solicitacao.TipoDeItem == ItemSolicitacao.ALUGUEL)
                {
                    return JsonConvert.DeserializeObject<Aluguel>(Solicitacao.ItemSerializado);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}