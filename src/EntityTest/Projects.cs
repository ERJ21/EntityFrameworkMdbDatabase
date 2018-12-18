using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class Projects
    {
        public Projects()
        {
            LightLocations = new HashSet<LightLocations>();
            Loads = new HashSet<Loads>();
            Notes = new HashSet<Notes>();
            ProjectsOperators = new HashSet<ProjectsOperators>();
        }

        public int ProjectId { get; set; }
        public string ProjectNumber { get; set; }
        public string ProjectName { get; set; }
        public string Location { get; set; }
        public string ProjectDescription { get; set; }
        public bool? ProjectIsActive { get; set; }
        public int Vessel { get; set; }

        public Vessels VesselNavigation { get; set; }
        public ICollection<LightLocations> LightLocations { get; set; }
        public ICollection<Loads> Loads { get; set; }
        public ICollection<Notes> Notes { get; set; }
        public ICollection<ProjectsOperators> ProjectsOperators { get; set; }
    }
}
