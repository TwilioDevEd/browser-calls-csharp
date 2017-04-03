using System.Web.Mvc;
using BrowserCalls.Web.Domain.Twilio;
using Twilio.AspNet.Mvc;
using Twilio.TwiML;

namespace BrowserCalls.Web.Controllers
{
    public class CallController : TwilioController
    {
        private readonly ICredentials _credentials;

        public CallController() : this(new Credentials()) {}

        public CallController(ICredentials credentials)
        {
            _credentials = credentials;
        }

        // POST Call/Connect
        [HttpPost]
        public TwiMLResult Connect(string phoneNumber)
        {
            var response = new VoiceResponse();

            var dial = new Dial(callerId: _credentials.PhoneNumber);
            if (phoneNumber != null)
            {
                dial.Number(phoneNumber);
            }
            else
            {
                dial.Client("support_agent");
            }
            response.Dial(dial);

            return TwiML(response);
        }
    }
}
