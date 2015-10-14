using Twilio;

namespace BrowserCalls.Web.Domain.Twilio
{
    public class Capability
    {
        private readonly ICredentials _credentials;

        public Capability(ICredentials credentials)
        {
            _credentials = credentials;
        }

        public string Generate(string role)
        {
            var capability = new TwilioCapability(_credentials.AccountSID, _credentials.AuthToken);
            capability.AllowClientOutgoing(_credentials.TwiMLApplicationSID);
            capability.AllowClientIncoming(role);

            return capability.GenerateToken();
        }
    }
}