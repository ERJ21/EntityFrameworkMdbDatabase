using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class ProjectsCaptains
    {
        public int ProjectCaptainId { get; set; }
        public int Project { get; set; }
        public int Captain { get; set; }
        public bool? ProjectCaptainIsActive { get; set; }

        public Captains CaptainNavigation { get; set; }
        public Projects ProjectNavigation { get; set; }
    }
}
