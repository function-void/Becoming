using Becoming.Core.Common.Abstractions.CQRS;

namespace Becoming.CoreTaskManager.Application.TaskManager.Commands.CreateTaskManager;

public sealed record class CreateTaskManagerCommand(string title) : ICommand<Guid>;

public sealed class CreateTaskManagerCommandHandler : ICommandHandler<CreateTaskManagerCommand, Guid>
{
    public Task<Guid> Handle(CreateTaskManagerCommand request, CancellationToken cancellationToken)
    {
        var taskManager = new TaskManager();
    }
}
