using MediatR;

namespace Becoming.Core.Common.Application.Concept;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
where TCommand : ICommand<TResponse>
{
    new Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken);
}
