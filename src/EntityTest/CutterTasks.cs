using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class CutterTasks
    {
        public int CutterEvent { get; set; }
        public int? CutterWork { get; set; }

        public Tasks CutterEventNavigation { get; set; }
        public CutterWorks CutterWorkNavigation { get; set; }
    }
}
