using System;
using System.Collections.Generic;

namespace BucBoard.Models.Entities
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public string Sender { get; set; }
        public string Reciever { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        public DateTime? Date { get; set; }
        public int? EventId { get; set; }

        public Event Event { get; set; }
    }
}
