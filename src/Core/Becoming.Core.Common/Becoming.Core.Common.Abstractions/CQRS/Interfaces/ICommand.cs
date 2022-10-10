using MediatR;

namespace Becoming.Core.Common.Abstractions.CQRS.Interfaces;

public interface ICommand : IRequest{ }

public interface ICommand<out TResponse> : IRequest<TResponse> { }