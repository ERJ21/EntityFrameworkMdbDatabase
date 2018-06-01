using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class Captains
    {
        public Captains()
        {
            ProjectsCaptains = new HashSet<ProjectsCaptains>();
        }

        public int CaptainId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<ProjectsCaptains> ProjectsCaptains { get; set; }
    }
}
