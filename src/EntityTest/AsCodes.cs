using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class AsCodes
    {
        public AsCodes()
        {
            Subcategories = new HashSet<Subcategories>();
        }

        public int AsCodeId { get; set; }
        public string CodeName { get; set; }
        public int EventType { get; set; }

        public EventTypes EventTypeNavigation { get; set; }
        public ICollection<Subcategories> Subcategories { get; set; }
    }
}
