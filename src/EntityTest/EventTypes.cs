using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class EventTypes
    {
        public EventTypes()
        {
            AsCodes = new HashSet<AsCodes>();
        }

        public int EventTypeId { get; set; }
        public string EventTypeName { get; set; }

        public ICollection<AsCodes> AsCodes { get; set; }
    }
}
