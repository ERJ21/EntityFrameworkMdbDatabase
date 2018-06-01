using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class HopperStates
    {
        public HopperStates()
        {
            StatesLog = new HashSet<StatesLog>();
        }

        public int HopperStateId { get; set; }
        public string StateName { get; set; }

        public ICollection<StatesLog> StatesLog { get; set; }
    }
}
