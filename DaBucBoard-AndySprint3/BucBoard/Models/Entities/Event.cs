using System;
using System.Collections.Generic;

namespace BucBoard.Models.Entities
{
    public partial class Event
    {
        public Event()
        {
            Message = new HashSet<Message>();
        }

        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? CalendarId { get; set; }

        public Calendar Calendar { get; set; }
        public Custom Custom { get; set; }
        public Premade Premade { get; set; }
        public Recurring Recurring { get; set; }
        public ICollection<Message> Message { get; set; }
    }
}
