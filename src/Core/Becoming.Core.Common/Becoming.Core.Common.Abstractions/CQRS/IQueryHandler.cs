using MediatR;

namespace Becoming.Core.Common.Abstractions.CQRS;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
    new Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken);
}