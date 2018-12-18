using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class Operators
    {
        public Operators()
        {
            ProjectsOperators = new HashSet<ProjectsOperators>();
        }

        public int OperatorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? ScreenIsAutomatic { get; set; }
        public int OperatorType { get; set; }
        public bool? OperatorIsActive { get; set; }

        public OperatorTypes OperatorTypeNavigation { get; set; }
        public ICollection<ProjectsOperators> ProjectsOperators { get; set; }
    }
}
