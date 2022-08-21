using MediatR;

namespace Becoming.Core.Common.Abstractions;

public interface IQuery<out TResponse> : IRequest<TResponse> { }