using System;
using System.ComponentModel.DataAnnotations;

namespace BrowserCalls.Web.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required, Display(Name = "Phone Number")]
        public String PhoneNumber { get; set; }

        [Required]
        public String Description { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
