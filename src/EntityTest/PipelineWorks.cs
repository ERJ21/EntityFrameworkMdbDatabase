using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class PipelineWorks
    {
        public int PipelineWorkId { get; set; }
        public int? Length { get; set; }
        public string Unit { get; set; }

        public PipelineDelays PipelineDelays { get; set; }
        public PipelineTasks PipelineTasks { get; set; }
    }
}
