using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class SubcategoriesUsaceCodes
    {
        public int Subcategory { get; set; }
        public int UsaceCode { get; set; }

        public Subcategories SubcategoryNavigation { get; set; }
        public UsaceCodes UsaceCodeNavigation { get; set; }
    }
}
