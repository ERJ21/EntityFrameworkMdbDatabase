using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class CutterSubcategories
    {
        public int CutterSubcategory { get; set; }

        public Subcategories CutterSubcategoryNavigation { get; set; }
    }
}
