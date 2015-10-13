using System;
using System.Data.Entity.Migrations;
using BrowserCalls.Web.Models;

namespace BrowserCalls.Web.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BrowserCallsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BrowserCallsContext context)
        {
            context.Tickets.AddOrUpdate(
                ticket => new {ticket.Name, ticket.PhoneNumber, ticket.Description, ticket.CreatedAt},
                new Ticket
                {
                    Name = "Charles Holdsworth",
                    PhoneNumber = "+14153674129",
                    Description = "I played for Middlesex in the championships and my mallet squeaked the whole time! I demand a refund!",
                    CreatedAt = DateTime.UtcNow
                },
                new Ticket
                {
                    Name = "John Woodger",
                    PhoneNumber = "+15712812415",
                    Description = "The mallet you sold me broke! Call me immediately!",
                    CreatedAt = DateTime.UtcNow
                });

            context.SaveChanges();
        }
    }
}
