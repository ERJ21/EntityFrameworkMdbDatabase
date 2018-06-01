using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class ProjectsChiefs
    {
        public int ProjectChiefId { get; set; }
        public int Project { get; set; }
        public int Chief { get; set; }
        public bool? ProjectChiefIsActive { get; set; }

        public Chiefs ChiefNavigation { get; set; }
        public Projects ProjectNavigation { get; set; }
    }
}
