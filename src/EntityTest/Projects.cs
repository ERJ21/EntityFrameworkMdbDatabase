using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class Projects
    {
        public Projects()
        {
            Loads = new HashSet<Loads>();
            Notes = new HashSet<Notes>();
            ProjectsCaptains = new HashSet<ProjectsCaptains>();
            ProjectsChiefs = new HashSet<ProjectsChiefs>();
            ProjectsOperators = new HashSet<ProjectsOperators>();
            Subjobs = new HashSet<Subjobs>();
        }

        public int ProjectId { get; set; }
        public string ProjectNumber { get; set; }
        public string ProjectName { get; set; }
        public string Location { get; set; }
        public string ProjectDescription { get; set; }
        public bool? ProjectIsActive { get; set; }
        public int Vessel { get; set; }

        public Vessels VesselNavigation { get; set; }
        public ICollection<Loads> Loads { get; set; }
        public ICollection<Notes> Notes { get; set; }
        public ICollection<ProjectsCaptains> ProjectsCaptains { get; set; }
        public ICollection<ProjectsChiefs> ProjectsChiefs { get; set; }
        public ICollection<ProjectsOperators> ProjectsOperators { get; set; }
        public ICollection<Subjobs> Subjobs { get; set; }
    }
}
