using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class Subcategories
    {
        public Subcategories()
        {
            Delays = new HashSet<Delays>();
            RamTasks = new HashSet<RamTasks>();
            Tasks = new HashSet<Tasks>();
        }

        public int SubcategoryId { get; set; }
        public string SubcategoryName { get; set; }
        public bool? IsActive { get; set; }
        public int AsCode { get; set; }
        public int Category { get; set; }

        public AsCodes AsCodeNavigation { get; set; }
        public Categories CategoryNavigation { get; set; }
        public CutterSubcategories CutterSubcategories { get; set; }
        public DefaultSubcategories DefaultSubcategories { get; set; }
        public LocalizedSubcategories LocalizedSubcategories { get; set; }
        public PipelineConfigurations PipelineConfigurations { get; set; }
        public SubcategoriesUsaceCodes SubcategoriesUsaceCodes { get; set; }
        public ICollection<Delays> Delays { get; set; }
        public ICollection<RamTasks> RamTasks { get; set; }
        public ICollection<Tasks> Tasks { get; set; }
    }
}
