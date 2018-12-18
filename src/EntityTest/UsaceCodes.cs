using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class UsaceCodes
    {
        public UsaceCodes()
        {
            SubcategoriesUsaceCodes = new HashSet<SubcategoriesUsaceCodes>();
        }

        public int UsaceCodeId { get; set; }
        public string UsaceCodeName { get; set; }
        public string UsaceCodeDescription { get; set; }

        public ICollection<SubcategoriesUsaceCodes> SubcategoriesUsaceCodes { get; set; }
    }
}
