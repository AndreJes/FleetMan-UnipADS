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
        const string API_KEY = "nL6pgKkgPVlBJ8uvPDFhazfFLP--V1DOau8jLnBHzw9N";
        const string API_URL = @"https://api.us-east.assistant.watson.cloud.ibm.com/instances/68fb7dc5-1455-49e1-a217-58b0cd6e9a9e";
        const string ASSISTANT_ID = @"27f4d612-10b7-4275-8e37-ed7cb055b2f3";

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