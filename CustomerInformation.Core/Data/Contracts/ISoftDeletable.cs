using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Harmony.Core.Data.Contracts
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
    }
}