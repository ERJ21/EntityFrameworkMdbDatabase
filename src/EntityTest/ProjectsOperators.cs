using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class ProjectsOperators
    {
        public ProjectsOperators()
        {
            Delays = new HashSet<Delays>();
            HopperCycles = new HashSet<HopperCycles>();
        }

        public int ProjectOperatorId { get; set; }
        public int Project { get; set; }
        public int Operator { get; set; }
        public bool? ProjectOperatorIsActive { get; set; }

        public Operators OperatorNavigation { get; set; }
        public Projects ProjectNavigation { get; set; }
        public ICollection<Delays> Delays { get; set; }
        public ICollection<HopperCycles> HopperCycles { get; set; }
    }
}
