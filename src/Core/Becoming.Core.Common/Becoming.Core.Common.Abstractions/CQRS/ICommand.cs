using MediatR;

namespace Becoming.Core.Common.Abstractions.CQRS;

public interface ICommand<out TResponse> : IRequest<TResponse> { }