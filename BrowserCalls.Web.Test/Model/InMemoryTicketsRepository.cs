using System.Collections.Generic;
using BrowserCalls.Web.Models;
using BrowserCalls.Web.Models.Repository;

namespace BrowserCalls.Web.Test.Model
{
    public class InMemoryTicketsRepository : ITicketsRepository
    {
        private readonly IList<Ticket> _db = new List<Ticket>();

        public void Create(Ticket ticket)
        {
            _db.Add(ticket);
        }

        public IEnumerable<Ticket> All()
        {
            return _db;
        }
    }
}
