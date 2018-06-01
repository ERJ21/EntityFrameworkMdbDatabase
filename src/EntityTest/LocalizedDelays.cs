using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class LocalizedDelays
    {
        public int LocalizedEvent { get; set; }
        public int? EventLocation { get; set; }

        public Locations EventLocationNavigation { get; set; }
        public Delays LocalizedEventNavigation { get; set; }
    }
}
