using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class Loads
    {
        public int LoadId { get; set; }
        public int? Project { get; set; }
        public DateTime? LoadDate { get; set; }
        public int? LoadNumber { get; set; }

        public Projects ProjectNavigation { get; set; }
    }
}
