using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class LocalizedSubcategories
    {
        public int LocalizedSubcategory { get; set; }

        public Subcategories LocalizedSubcategoryNavigation { get; set; }
    }
}
