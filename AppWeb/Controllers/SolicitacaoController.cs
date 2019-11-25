using AppWeb.Models.Helpers;
using AppWeb.Models.Solicitacoes;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Modelo.Classes.Clientes;
using Modelo.Classes.Web;
using Modelo.Enums;
using Persistencia.DAL.Clientes;
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

        private SolicitacaoService SolicitacaoService = new SolicitacaoService();

        // GET: Solicitacao
        [Authorize]
        public ActionResult Index()
        {
            string email = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            long? id = (long?)long.Parse(Gerenciador.FindByEmail(email).Id);
            if(id != null)
            {
                List<Solicitacao> solicitacoes = SolicitacaoService.ObterSolicitacoesOrdPorId().Where(s => s.ClienteId == id).ToList();
                return View(solicitacoes);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SolicitacaoViewModel solicitacaoView)
        {
            SolicitacaoService.RemoverSolicitacaoPorId(solicitacaoView.Solicitacao.SolicitacaoId);
            TempData["Message"] = "Solicitação Removida com Sucesso!";
            return RedirectToAction("Index");
        }
    }
}