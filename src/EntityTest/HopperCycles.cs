using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class HopperCycles
    {
        public HopperCycles()
        {
            RamTasks = new HashSet<RamTasks>();
            StatesLog = new HashSet<StatesLog>();
        }

        public int HopperCycleId { get; set; }
        public int? LoadNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public int? ProjectOperator { get; set; }
        public string CycleNote { get; set; }

        public ProjectsOperators ProjectOperatorNavigation { get; set; }
        public ICollection<RamTasks> RamTasks { get; set; }
        public ICollection<StatesLog> StatesLog { get; set; }
    }
}
