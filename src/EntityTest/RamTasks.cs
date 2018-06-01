using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class RamTasks
    {
        public int RamTaskId { get; set; }
        public int? HopperCycle { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public int? Subcategory { get; set; }
        public string Description { get; set; }
        public string OrderNumber { get; set; }

        public HopperCycles HopperCycleNavigation { get; set; }
        public Subcategories SubcategoryNavigation { get; set; }
        public LocalizedRamTasks LocalizedRamTasks { get; set; }
    }
}
