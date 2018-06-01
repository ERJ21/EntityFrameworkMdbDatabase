using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class VesselTypes
    {
        public VesselTypes()
        {
            Categories = new HashSet<Categories>();
            Vessels = new HashSet<Vessels>();
        }

        public int VesselTypeId { get; set; }
        public string VesselTypeName { get; set; }

        public ICollection<Categories> Categories { get; set; }
        public ICollection<Vessels> Vessels { get; set; }
    }
}
