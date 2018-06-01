using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class Pipes
    {
        public Pipes()
        {
            PipelineConfigurations = new HashSet<PipelineConfigurations>();
        }

        public int PipeId { get; set; }
        public int? PipeType { get; set; }
        public string PipeName { get; set; }

        public AsPipeTypes PipeTypeNavigation { get; set; }
        public ICollection<PipelineConfigurations> PipelineConfigurations { get; set; }
    }
}
