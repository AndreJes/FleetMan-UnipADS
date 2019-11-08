using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWeb.Controllers
{
    public class MotoristaController : Controller
    {
        // GET: Motorista
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}