using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class StatesLog
    {
        public int StateLogId { get; set; }
        public int? HopperCycle { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public int? HopperState { get; set; }
        public string StateNote { get; set; }

        public HopperCycles HopperCycleNavigation { get; set; }
        public HopperStates HopperStateNavigation { get; set; }
        public SlowBellLoggedStates SlowBellLoggedStates { get; set; }
    }
}
