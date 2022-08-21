using MediatR;

namespace Becoming.Core.Common.Abstractions;

public interface ICommand<out TResponse> : IRequest<TResponse> { }