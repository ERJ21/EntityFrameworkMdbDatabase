using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class PipelineDelays
    {
        public int PipelineEvent { get; set; }
        public int? PipelineWork { get; set; }

        public Delays PipelineEventNavigation { get; set; }
        public PipelineWorks PipelineWorkNavigation { get; set; }
    }
}
