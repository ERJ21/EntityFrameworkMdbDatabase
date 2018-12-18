using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class OperatorTypes
    {
        public OperatorTypes()
        {
            Operators = new HashSet<Operators>();
        }

        public int OperatorTypeId { get; set; }
        public string OperatorTypeName { get; set; }

        public ICollection<Operators> Operators { get; set; }
    }
}
