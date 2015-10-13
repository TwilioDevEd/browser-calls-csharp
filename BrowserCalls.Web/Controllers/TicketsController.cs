using System;
using System.Web.Mvc;
using BrowserCalls.Web.Models;
using BrowserCalls.Web.Models.Repository;

namespace BrowserCalls.Web.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketsRepository _repository;

        public TicketsController()
            : this(new TicketsRepository()) { }

        public TicketsController(ITicketsRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Create(
            [Bind(Include = "Name, PhoneNumber, Description")] Ticket ticket)
        {
            ticket.CreatedAt = DateTime.UtcNow;
            if (ModelState.IsValid)
            {
                _repository.Create(ticket);
                return RedirectToAction("Index", new { Controller = "Home" });
            }

            return View("~/Views/Home/Index.cshtml", ticket);
        }
    }
}