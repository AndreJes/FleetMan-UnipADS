using IBM.Cloud.SDK.Core.Authentication.Iam;
using IBM.Cloud.SDK.Core.Http;
using IBM.Watson.Assistant.v2;
using IBM.Watson.Assistant.v2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watson
{
    public class WatsonAssistantAPI
    {
        private string API_URL { get; set; }
        private string API_KEY { get; set; }
        private string ASSISTANT_ID { get; set; }

        private string SESSION_ID { get; set; }

        private IamAuthenticator _authenticator;
        private AssistantService _assistant;

        public WatsonAssistantAPI(string api_url, string api_key, string assistant_id)
        {
            try
            {
                API_KEY = api_key;
                API_URL = api_url;
                ASSISTANT_ID = assistant_id;

                _authenticator = new IamAuthenticator(
                       apikey: API_KEY
                       );

                _assistant = new AssistantService("2020-03-03", _authenticator);
                _assistant.SetServiceUrl(API_URL);

                var session = _assistant.CreateSession(
                    assistantId: ASSISTANT_ID
                    );

                SESSION_ID = session.Result.SessionId;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private MessageResponse DeserializeMessage(DetailedResponse<MessageResponse> message)
        {
            try
            {
                return JsonConvert.DeserializeObject<MessageResponse>(message.Response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetWelcomeMessage()
        {
            try
            {
                var result = _assistant.Message(
                        assistantId: ASSISTANT_ID,
                        sessionId: SESSION_ID
                    );

                var messageResponse = DeserializeMessage(result);

                return messageResponse.Output.Generic[0].Text;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<string> SendInput(MessageInput input)
        {
            try
            {
                var result = _assistant.Message(
                        assistantId: ASSISTANT_ID,
                        sessionId: SESSION_ID,
                        input: input
                    );

                var messageResponse = DeserializeMessage(result);

                List<string> results = new List<string>();

                foreach(RuntimeResponseGeneric rg in messageResponse.Output.Generic)
                {
                    results.Add(rg.Text);
                }

                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
