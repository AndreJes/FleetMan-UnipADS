using AppWeb.Models.Alugueis;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Modelo.Classes.Web;
using Modelo.Enums;
using Persistencia.DAL.Usuarios.Web;
using Servicos.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Globalization;

namespace AppWeb.Controllers
{
    public class AluguelController : Controller
    {
        public GerenciadorUsuarios Gerenciador
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuarios>();
            }
        }

        private AluguelService AluguelService = new AluguelService();
        private SolicitacaoService SolicitacaoService = new SolicitacaoService();

        // GET: Aluguel
        [Authorize]
        public ActionResult Index()
        {
            string email = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            long? id = (long?)long.Parse(Gerenciador.FindByEmail(email).Id);

            IEnumerable<Aluguel> alugueis = AluguelService.ObterAlugueisOrdPorId().Where(a => a.ClienteId == id).ToList();

            AluguelViewModel aluguelView = new AluguelViewModel() { Alugueis = alugueis };

            return View(aluguelView);
        }

        [Authorize]
        public ActionResult Detalhes(long? id)
        {
            string email = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            long? idCliente = (long?)long.Parse(Gerenciador.FindByEmail(email).Id);

            Aluguel aluguel = AluguelService.ObterAluguelPorId(id);

            if (aluguel != null)
            {
                if (aluguel.ClienteId != idCliente)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
                }

                return View(aluguel);
            }

            return HttpNotFound();
        }
    }
}