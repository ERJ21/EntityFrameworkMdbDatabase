using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class AsPipeTypes
    {
        public AsPipeTypes()
        {
            Pipes = new HashSet<Pipes>();
        }

        public int AsPipeTypeId { get; set; }
        public string AsPipeName { get; set; }

        public ICollection<Pipes> Pipes { get; set; }
    }
}
