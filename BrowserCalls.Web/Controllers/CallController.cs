using System.Web.Mvc;
using BrowserCalls.Web.Domain.Twilio;
using Twilio.TwiML;

namespace BrowserCalls.Web.Controllers
{
    public class CallController : Controller
    {
        private readonly ICredentials _credentials;

        public CallController() : this(new Credentials()) {}

        public CallController(ICredentials credentials)
        {
            _credentials = credentials;
        }

        // POST Call/Connect
        [HttpPost]
        public ActionResult Connect(string phoneNumber)
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

            return Content(response.ToString(), "application/xml");
        }
    }
}
