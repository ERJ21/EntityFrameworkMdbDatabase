using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class Locations
    {
        public Locations()
        {
            LocalizedDelays = new HashSet<LocalizedDelays>();
            LocalizedRamTasks = new HashSet<LocalizedRamTasks>();
            LocalizedTasks = new HashSet<LocalizedTasks>();
        }

        public int LocationId { get; set; }
        public string LocationName { get; set; }

        public ICollection<LocalizedDelays> LocalizedDelays { get; set; }
        public ICollection<LocalizedRamTasks> LocalizedRamTasks { get; set; }
        public ICollection<LocalizedTasks> LocalizedTasks { get; set; }
    }
}
