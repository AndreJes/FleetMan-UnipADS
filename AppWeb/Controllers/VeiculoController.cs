using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Modelo.Classes.Web;
using Persistencia.DAL.Usuarios.Web;
using Servicos.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AppWeb.Controllers
{
    public class VeiculoController : Controller
    {
        private GerenciadorUsuarios Gerenciador
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuarios>();
            }
        }

        private VeiculoService VeiculoService = new VeiculoService();

        // GET: Veiculo
        [Authorize]
        public ActionResult Index()
        {
            string email = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            long? id = (long?)long.Parse(Gerenciador.FindByEmail(email).Id);

            if(id != null)
            {
                List<Veiculo> veiculos = VeiculoService.ObterVeiculosOrdPorId().Where(v => v.ClienteId == id).ToList();
                return View(veiculos);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}