using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class Tasks
    {
        public int TaskId { get; set; }
        public int Delay { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public int Subcategory { get; set; }
        public string Description { get; set; }
        public string OrderNumber { get; set; }

        public Delays DelayNavigation { get; set; }
        public Subcategories SubcategoryNavigation { get; set; }
        public CutterTasks CutterTasks { get; set; }
        public LocalizedTasks LocalizedTasks { get; set; }
        public PipelineTasks PipelineTasks { get; set; }
    }
}
