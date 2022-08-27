using MediatR;

namespace Becoming.Core.Common.Abstractions.CQRS;

public interface IQuery<out TResponse> : IRequest<TResponse> { }