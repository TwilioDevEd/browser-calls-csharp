using System.Web.Configuration;

namespace BrowserCalls.Web.Domain.Twilio
{
    public interface ICredentials
    {
        string AccountSID { get; }
        string ApiKey { get; }
        string ApiSecret { get; }
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

        public string ApiKey
        {
        get
        {
            return WebConfigurationManager.AppSettings["TwilioApiKey"];
        }
        }

        public string ApiSecret
        {
        get
        {
            return WebConfigurationManager.AppSettings["TwilioApiSecret"];
        }
        }
    }
}