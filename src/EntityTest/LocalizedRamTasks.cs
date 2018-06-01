using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class LocalizedRamTasks
    {
        public int LocalizedEvent { get; set; }
        public int? EventLocation { get; set; }

        public Locations EventLocationNavigation { get; set; }
        public RamTasks LocalizedEventNavigation { get; set; }
    }
}
