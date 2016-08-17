using System;
using System.Collections.Generic;

namespace XXX.Models.ValueObjects
{
    public class SyncFilter
    {
        public DateTime? ModificationDate { get; set; }
        public IEnumerable<string> ExcludeExternalIds { get; set; }
    }
}