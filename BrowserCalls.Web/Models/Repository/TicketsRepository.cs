using System.Collections.Generic;
using System.Linq;

namespace BrowserCalls.Web.Models.Repository
{
    public interface ITicketsRepository
    {
        void Create(Ticket ticket);
        IEnumerable<Ticket> All();
    }

    public class TicketsRepository : ITicketsRepository
    {
        private readonly BrowserCallsContext _context;

        public TicketsRepository()
        {
            _context = new BrowserCallsContext();
        }

        public void Create(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
        }

        public IEnumerable<Ticket> All()
        {
            return _context.Tickets.ToList();
        }
    }
}
