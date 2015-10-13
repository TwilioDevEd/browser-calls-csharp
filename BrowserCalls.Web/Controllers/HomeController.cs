using System.Web.Mvc;
using BrowserCalls.Web.Models;

namespace BrowserCalls.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new Ticket());
        }
    }
}