using AppWeb.Models.Viagens;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Modelo.Classes.Web;
using Persistencia.DAL.Usuarios.Web;
using Servicos.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWeb.Controllers
{
    public class ViagemController : Controller
    {
        public GerenciadorUsuarios Gerenciador
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuarios>();
            }
        }

        private ViagemService ViagemService = new ViagemService();

        // GET: Viagem
        [Authorize]
        public ActionResult Index()
        {
            string email = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            long? id = (long?)long.Parse(Gerenciador.FindByEmail(email).Id);

            List<Viagem> viagens = ViagemService.ObterViagensOrdPorId().Where(v => v.Veiculo.ClienteId == id || v.MotoristaId == id).ToList();

            ViagemViewModel viagemView = new ViagemViewModel() { Viagens = viagens };

            return View(viagemView);
        }
    }
}