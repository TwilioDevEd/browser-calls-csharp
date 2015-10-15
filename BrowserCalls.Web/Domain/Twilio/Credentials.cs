using System.Web.Configuration;

namespace BrowserCalls.Web.Domain.Twilio
{
    public interface ICredentials
    {
        string AccountSID { get; }
        string AuthToken { get; }
        string TwiMLApplicationSID { get; }
        string PhoneNumber { get; }
    }

    public class Credentials : ICredentials
    {
        public string AccountSID
        {
            get
            {
                return WebConfigurationManager.AppSettings["TwilioAccountSid"];
            }
        }
        public string AuthToken
        {
            get
            {
                return WebConfigurationManager.AppSettings["TwilioAuthToken"];
            }
        }

        public string TwiMLApplicationSID {
            get
            {
                return WebConfigurationManager.AppSettings["TwiMLApplicationSid"];
            }
        }

        public string PhoneNumber {
            get
            {
                return WebConfigurationManager.AppSettings["TwilioPhoneNumber"];
            }
        }
    }
}