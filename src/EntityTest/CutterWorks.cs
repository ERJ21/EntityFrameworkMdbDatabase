using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class CutterWorks
    {
        public int CutterWorkId { get; set; }
        public int? Cutter { get; set; }
        public int? Tooth { get; set; }
        public int? TeethChanged { get; set; }

        public Cutters CutterNavigation { get; set; }
        public Teeth ToothNavigation { get; set; }
        public CutterDelays CutterDelays { get; set; }
        public CutterTasks CutterTasks { get; set; }
    }
}
