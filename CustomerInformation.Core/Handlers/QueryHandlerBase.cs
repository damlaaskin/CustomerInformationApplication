
using CustomerInformation.Core.CQRS.Contracts;
using MediatR;

namespace HR.Harmony.Core.CQRS.Handlers
{
    public abstract class QueryHandlerBase<TQuery, TResponse>
        : RequestHandler<TQuery, TResponse>
        where TQuery : class, IQuery<TResponse>
    {
    }

    public abstract class QueryHandlerBaseAsync<TQuery, TResponse>
        : AsyncRequestHandler<TQuery, TResponse>
        where TQuery : class, IQuery<TResponse>
    {
    }
}