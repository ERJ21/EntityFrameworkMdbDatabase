using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class PipelineWorkTypes
    {
        public PipelineWorkTypes()
        {
            PipelineConfigurations = new HashSet<PipelineConfigurations>();
        }

        public int PipelineWorkTypeId { get; set; }
        public string WorkType { get; set; }

        public ICollection<PipelineConfigurations> PipelineConfigurations { get; set; }
    }
}
