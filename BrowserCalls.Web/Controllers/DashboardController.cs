using System.Web.Mvc;
using BrowserCalls.Web.Models.Repository;

namespace BrowserCalls.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ITicketsRepository _repository;

        public DashboardController() : this(new TicketsRepository()) {}

        public DashboardController(ITicketsRepository repository)
        {
            _repository = repository;
        }
        // GET: Dashboard
        public ActionResult Index()
        {
            var tickets = _repository.All();
            return View(tickets);
        }
    }
}