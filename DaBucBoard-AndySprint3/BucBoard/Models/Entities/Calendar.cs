using System;
using System.Collections.Generic;

namespace BucBoard.Models.Entities
{
    public partial class Calendar
    {
        public Calendar()
        {
            Event = new HashSet<Event>();
        }

        public int CalendarId { get; set; }
        public string Month { get; set; }
        public int? UserId { get; set; }

        public User User { get; set; }
        public ICollection<Event> Event { get; set; }
    }
}
