

using CustomerInformation.Core.CQRS.Contracts;
using CustomerInformation.Core.CQRS.Domain;
using MediatR;


namespace CustomerInformation.Core.CQRS.Handlers
{
    public abstract class CommandHandlerBase<TCommand>
        : RequestHandler<TCommand, CommandResult>
    where TCommand : class, ICommand
    {
    }

    public abstract class CommandHandlerBaseAsync<TCommand>
        : AsyncRequestHandler<TCommand, CommandResult>
        where TCommand : class, ICommand
    {
    }
}