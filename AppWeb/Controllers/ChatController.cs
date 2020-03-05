using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace AppWeb.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult GetMessage()
        {
            return new JsonResult { Data = new {Message = "Hello JSON!", Number = 1 }, JsonRequestBehavior = JsonRequestBehavior.AllowGet, ContentType = "application/json" };
        }
    }
}