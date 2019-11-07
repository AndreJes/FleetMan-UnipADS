using AppWeb.Models.Helpers;
using AppWeb.Models.Solicitacoes;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Modelo.Classes.Clientes;
using Modelo.Classes.Web;
using Modelo.Enums;
using Persistencia.DAL.Cliente;
using Persistencia.DAL.Usuarios.Web;
using Servicos.Clientes;
using Servicos.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AppWeb.Controllers
{
    public class SolicitacaoController : Controller
    {
        private GerenciadorUsuarios Gerenciador
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuarios>();
            }
        }

        private ClienteHelper ClienteHelper = new ClienteHelper();
        private ClienteService ClienteService = new ClienteService();
        private SolicitacaoService SolicitacaoService = new SolicitacaoService();

        // GET: Solicitacao
        public ActionResult Index()
        {
            string email = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            TipoCliente tipo = ClienteHelper.ObterTipoClientePorEmail(email);

            switch (tipo)
            {
                case TipoCliente.PF:
                    ClientePF clientePF = ClienteService.ObterClientePFPorEmail(email);
                    List<Solicitacao> solicitacoesPF = SolicitacaoService.ObterSolicitacoesOrdPorId().Where(s => s.ClienteId == clientePF.ClienteId).ToList();
                    return View(solicitacoesPF);

                case TipoCliente.PJ:
                    ClientePJ clientePJ = ClienteService.ObterClientePJPorEmail(email);
                    List<Solicitacao> solicitacoesPJ = SolicitacaoService.ObterSolicitacoesOrdPorId().Where(s => s.ClienteId == clientePJ.ClienteId).ToList();
                    return View(solicitacoesPJ);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        public ActionResult Delete(long? id)
        {
            if (id != null)
            {
                Solicitacao solicitacao = SolicitacaoService.ObterSolicitacaoPorId(id);
                if (solicitacao != null)
                {
                    if (solicitacao.ClienteId.ToString() != Gerenciador.FindByEmail(HttpContext.GetOwinContext().Authentication.User.Identity.Name).Id)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
                    }
                    SolicitacaoViewModel solicitacaoView = new SolicitacaoViewModel() { Solicitacao = solicitacao };
                    return View(solicitacaoView);
                }
                else
                {
                    return new HttpNotFoundResult("Item não encontrado");
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}