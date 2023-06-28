using MediatR;

namespace Becoming.Core.Common.Application.Concept;

public interface ICommand : IRequest { }

public interface ICommand<out TResponse> : IRequest<TResponse> { }
