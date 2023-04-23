
using CustomerInformation.Core.CQRS.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Harmony.Core.CQRS.Domain
{
    public abstract class EventBase : IEvent
    {
        public DateTime Timestamp => DateTime.Now;
    }
}