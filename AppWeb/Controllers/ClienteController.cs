﻿using AppWeb.Models.ClienteUsuario;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Modelo.Classes.Auxiliares;
using Modelo.Classes.Clientes;
using Modelo.Classes.Usuarios;
using Modelo.Classes.Web;
using Modelo.Enums;
using Persistencia.DAL.Usuarios.Web;
using Servicos.Clientes;
using Servicos.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace AppWeb.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteService ClienteService = new ClienteService();
        private SolicitacaoService SolicitacaoService = new SolicitacaoService();

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

        [Authorize]
        public ActionResult EditPF()
        {
            string email = HttpContext.GetOwinContext().Authentication.User.Identity.Name;

            Cliente cliente = ClienteService.ObterClientePorEmailTipo(email, TipoCliente.PF);

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

            return HttpNotFound("Informações do usuário não encontradas");
        }

        [Authorize]
        public ActionResult EditPJ()
        {
            string email = HttpContext.GetOwinContext().Authentication.User.Identity.Name;

            Cliente cliente = ClienteService.ObterClientePorEmailTipo(email, TipoCliente.PJ);

            if (cliente != null)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPF(ClientePFViewModel pageModel)
        {
            if (ModelState.IsValid)
            {
                ClientePF clientePF = null;
                clientePF = ClienteService.ObterClientePFPorId(pageModel.ClienteId);
                clientePF.Nome = pageModel.Nome;
                string telefone = TrimUnwantedChars(pageModel.Telefone, new char[] { '-', '(', ')' });
                clientePF.Telefone = telefone;
                string cpf = TrimUnwantedChars(pageModel.CPF, new char[] { '.', '-' });
                clientePF.CPF = cpf;
                string cep = TrimUnwantedChars(pageModel.Endereco.CEP, new char[] { '-' });
                clientePF.Endereco = pageModel.Endereco;
                clientePF.Endereco.CEP = cep;
                clientePF.Tipo = TipoCliente.PF;
                Solicitacao solicitacao = SolicitacaoService.GerarSolicitacao(ItemSolicitacao.CLIENTE, TiposDeSolicitacao.ALTERACAO, clientePF.ClienteId, clientePF);
                SolicitacaoService.GravarSolicitacao(solicitacao);
                TempData["Message"] = "Solicitação enviada com sucesso!";
                return RedirectToAction("Details");

            }

            return View(pageModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPJ(ClientePJViewModel pageModel)
        {
            if (ModelState.IsValid)
            {
                ClientePJ clientePJ = null;
                clientePJ = ClienteService.ObterClientePJPorId(pageModel.ClienteId);
                clientePJ.Nome = pageModel.Nome;
                string telefone = TrimUnwantedChars(pageModel.Telefone, new char[] { '-', '(', ')' });
                clientePJ.Telefone = telefone;
                string cnpj = TrimUnwantedChars(pageModel.CNPJ, new char[] { '.', '-', '/' });
                clientePJ.CNPJ = cnpj;
                string cep = TrimUnwantedChars(pageModel.Endereco.CEP, new char[] { '-' });
                clientePJ.Endereco = pageModel.Endereco;
                clientePJ.Endereco.CEP = cep;
                clientePJ.Tipo = TipoCliente.PJ;
                Solicitacao solicitacao = SolicitacaoService.GerarSolicitacao(ItemSolicitacao.CLIENTE, TiposDeSolicitacao.ALTERACAO, clientePJ.ClienteId, clientePJ);
                SolicitacaoService.GravarSolicitacao(solicitacao);
                TempData["Message"] = "Solicitação enviada com sucesso!";
                return RedirectToAction("Details");

            }

            return View(pageModel);
        }

        private string TrimUnwantedChars(string input, char[] chars)
        {
            foreach (char c in chars)
            {
                input = input.Replace(c.ToString(), "");
            }
            return input;
        }
    }
}