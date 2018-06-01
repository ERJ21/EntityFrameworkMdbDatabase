using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class CutterDelays
    {
        public int CutterEvent { get; set; }
        public int? CutterWork { get; set; }

        public Delays CutterEventNavigation { get; set; }
        public CutterWorks CutterWorkNavigation { get; set; }
    }
}
