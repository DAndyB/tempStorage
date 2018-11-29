using System;
using System.Collections.Generic;

namespace BucBoard.Models.Entities
{
    public partial class Custom
    {
        public byte? IsAvalible { get; set; }
        public int? EventType { get; set; }
        public int EventId { get; set; }

        public Event Event { get; set; }
    }
}
