using AppWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Modelo.Classes.Usuarios;
using Persistencia.DAL.Usuarios.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace AppWeb.Controllers
{
    public class AccountController : Controller
    {
        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private GerenciadorUsuarios Gerenciador
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuarios>();
            }
        }

        // GET: Login
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        public ActionResult Logout()
        {
            AuthManager.SignOut();
            return RedirectToAction("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                UsuarioCliente usuario = Gerenciador.Find(model.Email, model.Senha);
                if(usuario == null)
                {
                    @ViewBag.Error = "Usuário não encontrado!";
                }
                else
                {
                    ClaimsIdentity identity = Gerenciador.CreateIdentity(usuario, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);
                    if(returnUrl == null)
                    {
                        returnUrl = "/Home";
                    }
                    return Redirect(returnUrl);
                }
            }
            return View(model);
        }
    }
}