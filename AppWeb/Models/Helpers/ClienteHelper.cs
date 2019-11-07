using Modelo.Classes.Clientes;
using Modelo.Enums;
using Servicos.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWeb.Models.Helpers
{
    public class ClienteHelper
    {
        private ClienteService ClienteService = new ClienteService();

        public TipoCliente ObterTipoClientePorEmail(string email)
        {
            Cliente cliente = ClienteService.ObterClientePorEmailTipo(email, TipoCliente.PF);
            if (cliente == null)
            {
                return TipoCliente.PJ;
            }
            return TipoCliente.PF;
        }
    }
}