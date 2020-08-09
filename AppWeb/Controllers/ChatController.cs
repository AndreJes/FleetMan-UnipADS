using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Watson;

namespace AppWeb.Controllers
{
    public class ChatController : Controller
    {
        const string API_KEY = "";
        const string API_URL = @"";
        const string ASSISTANT_ID = @"";

        WatsonAssistantAPI assistantAPI = new WatsonAssistantAPI(API_URL, API_KEY, ASSISTANT_ID);


        // GET: Chat
        public ActionResult GetWelcomeMessage()
        {
            return new JsonResult { Data = new { Message = assistantAPI.GetWelcomeMessage() }, JsonRequestBehavior = JsonRequestBehavior.AllowGet, ContentType = "application/json" };
        }

        [HttpPost]
        public ActionResult SendMessage(string input)
        {
            List<string> results = assistantAPI.SendInput(new IBM.Watson.Assistant.v2.Model.MessageInput() { Text = input });
            return new JsonResult() { Data = new { results }, JsonRequestBehavior = JsonRequestBehavior.AllowGet, ContentType = "application/json" };
        }
    }
}
