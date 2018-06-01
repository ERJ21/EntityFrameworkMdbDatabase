using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class PipelineConfigurations
    {
        public int PipelineSubcategory { get; set; }
        public int? PipelineWorkType { get; set; }
        public int? Pipe { get; set; }

        public Pipes PipeNavigation { get; set; }
        public Subcategories PipelineSubcategoryNavigation { get; set; }
        public PipelineWorkTypes PipelineWorkTypeNavigation { get; set; }
    }
}
