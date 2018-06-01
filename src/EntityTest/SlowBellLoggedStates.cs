using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class SlowBellLoggedStates
    {
        public int LoggedState { get; set; }
        public int? OverheadDuration { get; set; }

        public StatesLog LoggedStateNavigation { get; set; }
    }
}
