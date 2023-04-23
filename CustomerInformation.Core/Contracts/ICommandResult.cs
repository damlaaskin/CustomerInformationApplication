
using System.Collections.Generic;

namespace CustomerInformation.Core.CQRS.Contracts
{
    public interface ICommandResult
    {
        bool IsSuccess { get; }
        string Message { get; }
        int? CreatedObjectRef { get; }
        List<IEvent> CommandEvents { get; }
    }
}