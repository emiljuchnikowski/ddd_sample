using System;

namespace XXX.Models.ValueObjects
{
    public interface ISync
    {
        DateTime ModificationDate { get; set; }
        string ExternalId { get; set; }
        bool Deleted { get; set; }
    }
}