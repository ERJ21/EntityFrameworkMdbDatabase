using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class Delays
    {
        public Delays()
        {
            Tasks = new HashSet<Tasks>();
        }

        public int DelayId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public int Subcategory { get; set; }
        public string OrderNumber { get; set; }
        public string Description { get; set; }
        public int? ProjectOperator { get; set; }

        public ProjectsOperators ProjectOperatorNavigation { get; set; }
        public Subcategories SubcategoryNavigation { get; set; }
        public CutterDelays CutterDelays { get; set; }
        public LocalizedDelays LocalizedDelays { get; set; }
        public PipelineDelays PipelineDelays { get; set; }
        public RegularHopperDelays RegularHopperDelays { get; set; }
        public ICollection<Tasks> Tasks { get; set; }
    }
}
