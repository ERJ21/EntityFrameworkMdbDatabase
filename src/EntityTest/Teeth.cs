using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class Teeth
    {
        public Teeth()
        {
            CutterWorks = new HashSet<CutterWorks>();
        }

        public int ToothId { get; set; }
        public string ToothName { get; set; }

        public ICollection<CutterWorks> CutterWorks { get; set; }
    }
}
