using System.Data.Entity;

namespace BrowserCalls.Web.Models
{
    public class BrowserCallsContext : DbContext
    {
        public BrowserCallsContext() : base("DefaultConnection")
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
    }
}
