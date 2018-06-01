using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class RegularHopperDelays
    {
        public int RegularDelayId { get; set; }
        public int? LoggedHopperState { get; set; }

        public Delays RegularDelay { get; set; }
    }
}
