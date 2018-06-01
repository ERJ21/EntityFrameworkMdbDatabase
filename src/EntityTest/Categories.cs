using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class Categories
    {
        public Categories()
        {
            Subcategories = new HashSet<Subcategories>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? VesselType { get; set; }

        public VesselTypes VesselTypeNavigation { get; set; }
        public ICollection<Subcategories> Subcategories { get; set; }
    }
}
