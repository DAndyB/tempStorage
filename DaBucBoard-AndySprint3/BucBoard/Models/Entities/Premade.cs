using System;
using System.Collections.Generic;

namespace BucBoard.Models.Entities
{
    public partial class Premade
    {
        public int? EventType { get; set; }
        public int EventId { get; set; }

        public Event Event { get; set; }
    }
}
