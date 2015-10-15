using System;
using System.Web.Mvc;
using System.Web.Routing;
using BrowserCalls.Web.Controllers;
using BrowserCalls.Web.Models;
using BrowserCalls.Web.Models.Repository;
using BrowserCalls.Web.Test.Model;
using NUnit.Framework;

// ReSharper disable PossibleNullReferenceException

namespace BrowserCalls.Web.Test.Controllers
{
    public class HomeControllerTest
    {
        [Test]
        public void GivenACreateAction_WhenTheTicketIsValid_ThenItIsCreated()
        {
            var repository = new InMemoryTicketsRepository();
            var controller = GetTicketsController(repository);

            var ticket = new Ticket
            {
                Name = "name",
                PhoneNumber = "phone",
                Description = "description",
                CreatedAt = new DateTime(1985, 8, 26)
            };
            controller.Create(ticket);

            var tickets = repository.All();
            Assert.That(tickets, Contains.Item(ticket));
        }

        [Test]
        public void GivenACreateAction_WhenTheTicketIsInvalid_ThenRenderHomeIndexView()
        {
            var controller = GetTicketsController(new InMemoryTicketsRepository());
            controller.ModelState.AddModelError("", "Name is required");

            var ticket = new Ticket();
            var result = controller.Create(ticket) as ViewResult;

            Assert.That(result.ViewName, Is.EqualTo("~/Views/Home/Index.cshtml"));
        }

        private static TicketsController GetTicketsController(ITicketsRepository repository)
        {
            var controller = new TicketsController(repository);

            controller.ControllerContext = new ControllerContext
            {
                Controller = controller,
                RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
            };

            return controller;
        }
    }
}