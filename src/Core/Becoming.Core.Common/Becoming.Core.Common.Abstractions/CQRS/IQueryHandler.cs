using MediatR;

namespace Becoming.Core.Common.Abstractions.CQRS;

public interface IQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IQuery<TResponse>
{ }