using AppWeb.Models.Motoristas;
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
    public class MotoristaController : Controller
    {
        private GerenciadorUsuarios Gerenciador
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuarios>();
            }
        }

        private MotoristaService MotoristaService = new MotoristaService();

        // GET: Motorista
        [Authorize]
        public ActionResult Index()
        {
            string email = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            long? id = (long?)long.Parse(Gerenciador.FindByEmail(email).Id);

            List<Motorista> motoristas = MotoristaService.ObterMotoristasOrdPorId().Where(m => m.MotoristaId == id).ToList();

            return View(motoristas);
        }

        [Authorize]
        public ActionResult Details(long? id)
        {
            string email = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            long? idCliente = (long?)long.Parse(Gerenciador.FindByEmail(email).Id);

            if (id != null)
            {
                Motorista motorista = MotoristaService.ObterMotoristaPorId(id);

                if (motorista != null)
                {
                    if (motorista.ClienteId != idCliente)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
                    }

                    MotoristaViewModel motoristaView = new MotoristaViewModel() { Motorista = motorista };

                    return View(motoristaView);
                }

            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }
    }
}