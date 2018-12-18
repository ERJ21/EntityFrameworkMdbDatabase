using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class LightLogEntries
    {
        public int LightLogEntryId { get; set; }
        public int Location { get; set; }
        public int EntryType { get; set; }
        public DateTime EntryDate { get; set; }
        public string Note { get; set; }

        public LightLogEntryTypes EntryTypeNavigation { get; set; }
        public LightLocations LocationNavigation { get; set; }
    }
}
