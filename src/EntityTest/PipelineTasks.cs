using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class PipelineTasks
    {
        public int PipelineEvent { get; set; }
        public int? PipelineWork { get; set; }

        public Tasks PipelineEventNavigation { get; set; }
        public PipelineWorks PipelineWorkNavigation { get; set; }
    }
}
