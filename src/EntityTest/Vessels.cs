using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class Vessels
    {
        public Vessels()
        {
            Projects = new HashSet<Projects>();
        }

        public int VesselId { get; set; }
        public int? VesselType { get; set; }
        public string VesselName { get; set; }

        public VesselTypes VesselTypeNavigation { get; set; }
        public ICollection<Projects> Projects { get; set; }
    }
}
