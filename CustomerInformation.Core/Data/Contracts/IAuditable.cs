using HR.Harmony.Core.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerInformation.Core.Data.Contracts
{
    public interface IAuditable : ISoftDeletable
    {
        DateTime CreatedDate { get; set; }
        int CreatedBy { get; set; }
        DateTime ModifiedDate { get; set; }
        int ModifiedBy { get; set; }
    }
}