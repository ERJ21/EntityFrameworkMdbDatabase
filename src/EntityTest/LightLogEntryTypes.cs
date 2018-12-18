using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class LightLogEntryTypes
    {
        public LightLogEntryTypes()
        {
            LightLogEntries = new HashSet<LightLogEntries>();
        }

        public int LightLogEntryTypeId { get; set; }
        public string EntryTypeName { get; set; }
        public string Description { get; set; }

        public ICollection<LightLogEntries> LightLogEntries { get; set; }
    }
}
