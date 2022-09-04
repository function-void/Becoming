using Becoming.Core.Common.Abstractions.CQRS;

namespace Becoming.Core.TaskManager.Application.Commands.CreateTaskManager;

public sealed record class CreateTaskManagerCommand(string Title) : ICommand<Guid>;

public sealed class CreateTaskManagerCommandHandler : ICommandHandler<CreateTaskManagerCommand, Guid>
{
    public Task<Guid> Handle(CreateTaskManagerCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Guid.NewGuid());
    }
}
