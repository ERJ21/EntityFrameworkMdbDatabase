using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class Chiefs
    {
        public Chiefs()
        {
            ProjectsChiefs = new HashSet<ProjectsChiefs>();
        }

        public int ChiefId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<ProjectsChiefs> ProjectsChiefs { get; set; }
    }
}
