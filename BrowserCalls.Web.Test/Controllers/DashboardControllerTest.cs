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
    public class DashboardControllerTest
    {
        [Test]
        public void GivenADashboardIndexRequest_ThenRespondAListOfExistingTickets()
        {
            var repository = new InMemoryTicketsRepository();
            repository.Create(new Ticket {Name = "ticket-one"});
            repository.Create(new Ticket {Name = "ticket-two"});

            var controller = GetDashboardController(repository);
            var result = controller.Index() as ViewResult;

            Assert.That(result.ViewData.Model, Is.EqualTo(repository.All()));
        }


        private static DashboardController GetDashboardController(ITicketsRepository repository)
        {
            var controller = new DashboardController(repository);

            controller.ControllerContext = new ControllerContext
            {
                Controller = controller,
                RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
            };

            return controller;
        }
    }
}
