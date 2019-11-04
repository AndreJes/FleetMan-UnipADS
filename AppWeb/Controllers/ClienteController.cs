using AppWeb.Models.ClienteUsuario;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Modelo.Classes.Auxiliares;
using Modelo.Classes.Clientes;
using Modelo.Classes.Usuarios;
using Modelo.Enums;
using Persistencia.DAL.Usuarios.Web;
using Servicos.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWeb.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteService ClienteService = new ClienteService();

        private GerenciadorUsuarios Gerenciador
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuarios>();
            }
        }

        // GET: Cliente
        [Authorize]
        public ActionResult Details()
        {
            string email = HttpContext.GetOwinContext().Authentication.User.Identity.Name;

            Cliente cliente = ClienteService.ObterClientePorEmailTipo(email, TipoCliente.PF);
            if (cliente == null)
            {
                cliente = ClienteService.ObterClientePorEmailTipo(email, TipoCliente.PJ);
            }
            if (cliente.Tipo == TipoCliente.PF)
            {
                ClientePFViewModel clienteView = new ClientePFViewModel();
                clienteView.CPF = (cliente as ClientePF).CPF;
                clienteView.ClienteId = cliente.ClienteId;
                clienteView.Nome = cliente.Nome;
                clienteView.Telefone = cliente.Telefone;
                clienteView.Endereco = cliente.Endereco;
                return View(clienteView);
            }
            else if (cliente.Tipo == TipoCliente.PJ)
            {
                ClientePJViewModel clienteView = new ClientePJViewModel();
                clienteView.CNPJ = (cliente as ClientePJ).CNPJ;
                clienteView.ClienteId = cliente.ClienteId;
                clienteView.Nome = cliente.Nome;
                clienteView.Telefone = cliente.Telefone;
                clienteView.Endereco = cliente.Endereco;
                return View(clienteView);
            }

            return HttpNotFound("Informações do usuário não encontradas");
        }
    }
}