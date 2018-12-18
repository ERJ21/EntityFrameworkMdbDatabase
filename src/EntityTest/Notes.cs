using System;
using System.Collections.Generic;

namespace EntityTest
{
    public partial class Notes
    {
        public int NoteId { get; set; }
        public DateTime NoteDate { get; set; }
        public string Note { get; set; }
        public int? ProjectId { get; set; }
        public int? Fuel { get; set; }
        public int? Water { get; set; }

        public Projects Project { get; set; }
    }
}
