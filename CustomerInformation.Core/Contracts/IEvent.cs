using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerInformation.Core.CQRS.Contracts
{
    public interface IEvent : INotification
    {
        DateTime Timestamp { get; }
    }
}