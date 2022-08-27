using MediatR;

namespace Becoming.Core.Common.Abstractions.CQRS;

public interface ICommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
{ }
