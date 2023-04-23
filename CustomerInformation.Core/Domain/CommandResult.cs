

using CustomerInformation.Core.CQRS.Contracts;
using System.Collections.Generic;

namespace CustomerInformation.Core.CQRS.Domain
{
    public class CommandResult : ICommandResult
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public int? CreatedObjectRef { get; set; }
        public List<IEvent> CommandEvents { get; }

        public CommandResult()
        {
        }

        public CommandResult(IEvent @event)
        {
            CommandEvents = new List<IEvent>
            {
                @event
            };
        }

        public CommandResult(List<IEvent> events)
        {
            CommandEvents = events;
        }
    }
}