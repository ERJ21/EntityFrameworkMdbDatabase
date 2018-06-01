using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class LocalizedTasks
    {
        public int LocalizedEvent { get; set; }
        public int? EventLocation { get; set; }

        public Locations EventLocationNavigation { get; set; }
        public Tasks LocalizedEventNavigation { get; set; }
    }
}
