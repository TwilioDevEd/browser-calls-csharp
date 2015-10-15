using System.Web.Mvc;
using BrowserCalls.Web.Domain.Twilio;
using Twilio.TwiML;
using Twilio.TwiML.Mvc;

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
            return TwiML(BuildResponse(phoneNumber));
        }

        private TwilioResponse BuildResponse(string phoneNumber)
        {
            var response = new TwilioResponse();
            var callerIDAttribute = new {callerId = _credentials.PhoneNumber};
            if (phoneNumber != null)
            {
                response.Dial(callerIDAttribute,
                    new Number(phoneNumber));
            }
            else
            {
                response.Dial(callerIDAttribute,
                    new Client("support_agent"));
            }

            return response;
        }
    }
}
