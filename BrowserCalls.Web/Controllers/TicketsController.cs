using System;
using System.Web.Mvc;
using BrowserCalls.Web.Models;
using BrowserCalls.Web.Models.Repository;

namespace BrowserCalls.Web.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketsRepository _repository;

        public TicketsController() : this(new TicketsRepository()) { }

        public TicketsController(ITicketsRepository repository)
        {
            _repository = repository;
        }
        public ActionResult Index()
        {
            return View(new Ticket());
        }

        public ActionResult Create(
            [Bind(Include = "Name, PhoneNumber, Description")] Ticket ticket)
        {
            ticket.CreatedAt = DateTime.UtcNow;
            if (ModelState.IsValid)
            {
                _repository.Create(ticket);
                ViewBag.Success = "Your ticket was submitted! An agent will call you soon.";
                ModelState.Clear();
                return View("Index");
            }

            return View("Index");
        }
    }
}
