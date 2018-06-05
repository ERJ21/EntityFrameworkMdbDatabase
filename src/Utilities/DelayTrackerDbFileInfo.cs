using System;
using System.Collections.Generic;

namespace Utilities
{
    public class DelayTrackerDbFileInfo
    {
        public DelayTrackerDbFileInfo(string filePath, IEnumerable<string> tableNames)
        {
            FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
            TableNames = tableNames;
        }

        public string FilePath { get; }

        public IEnumerable<string> TableNames { get; }
    }
}
