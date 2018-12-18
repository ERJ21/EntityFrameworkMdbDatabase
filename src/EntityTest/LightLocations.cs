using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class LightLocations
    {
        public LightLocations()
        {
            LightLogEntries = new HashSet<LightLogEntries>();
        }

        public int LightLocationId { get; set; }
        public string LocationName { get; set; }
        public string Description { get; set; }
        public int Project { get; set; }

        public Projects ProjectNavigation { get; set; }
        public ICollection<LightLogEntries> LightLogEntries { get; set; }
    }
}
