using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class Subjobs
    {
        public int SubjobId { get; set; }
        public string Code { get; set; }
        public DateTime? StartDate { get; set; }
        public int? Project { get; set; }

        public Projects ProjectNavigation { get; set; }
    }
}
