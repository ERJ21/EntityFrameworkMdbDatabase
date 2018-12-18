using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class Cutters
    {
        public Cutters()
        {
            CutterWorks = new HashSet<CutterWorks>();
        }

        public int CutterId { get; set; }
        public string CutterName { get; set; }
        public bool? IsActive { get; set; }

        public ICollection<CutterWorks> CutterWorks { get; set; }
    }
}
