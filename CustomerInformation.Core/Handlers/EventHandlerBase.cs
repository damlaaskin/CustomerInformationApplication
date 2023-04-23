
using CustomerInformation.Core.CQRS.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Harmony.Core.CQRS.Handlers
{
    public abstract class EventHandlerBase<TEvent> : INotificationHandler<TEvent>
        where TEvent : class, IEvent
    {
        public Task Handle(TEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }

    public abstract class EventHandlerBaseAsync<TEvent> : AsyncNotificationHandler<TEvent>
        where TEvent : class, IEvent
    {
    }
}