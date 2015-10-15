using System.Web.Mvc;
using BrowserCalls.Web.Domain.Twilio;

namespace BrowserCalls.Web.Controllers
{
    public class TokenController : Controller
    {
        private readonly ICredentials _credentials;

        public TokenController() : this(new Credentials()) {}

        public TokenController(ICredentials credentials)
        {
            _credentials = credentials;
        }

        // GET: Token/Generate
        public JsonResult Generate(string page)
        {
            var token = new Capability(_credentials).Generate(InferRole(page));
            return Json(new {token}, JsonRequestBehavior.AllowGet);
        }

        private static string InferRole(string page)
        {
            return page.Equals("role") ? "support_agent" : "customer";
        }
    }
}