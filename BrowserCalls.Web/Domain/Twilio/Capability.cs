using System.Collections.Generic;
using Twilio.Jwt.AccessToken;

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
            // Load Twilio configuration from Web.config
            var twilioAccountSid = _credentials.AccountSID;
            var appSid = _credentials.TwiMLApplicationSID;
            var twilioApiKey = _credentials.ApiKey;
            var twilioApiSecret = _credentials.ApiSecret;

            // Create a Voice grant for this token
            var grant = new VoiceGrant();
            grant.OutgoingApplicationSid = appSid;

            // Optional: add to allow incoming calls
            grant.IncomingAllow = true;

            var grants = new HashSet<IGrant>
                {
                    { grant }
                };

            // Create an Access Token generator
            var accessToken = new Token(
                twilioAccountSid,
                twilioApiKey,
                twilioApiSecret,
                role,
                grants: grants);

            return accessToken.ToJwt();

        }
    }
}