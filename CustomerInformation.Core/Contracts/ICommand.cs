using CustomerInformation.Core.CQRS.Domain;
using HR.Harmony.Core.CQRS.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerInformation.Core.CQRS.Contracts
{
    public interface ICommand : IRequest<CommandResult>
    {
        DateTime Timestamp { get; }
    }
}