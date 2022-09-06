using Becoming.Core.Common.Abstractions.CQRS;
using Becoming.Core.TaskManager.Domain.Models;
using Becoming.Core.TaskManager.Domain.Repositories;

namespace Becoming.Core.TaskManager.Application.Commands.CreateTaskManager;

public sealed record class CreateTaskManagerCommand(string Title, string Category) : ICommand<Guid>;

public sealed class CreateTaskManagerCommandHandler : ICommandHandler<CreateTaskManagerCommand, Guid>
{
    private readonly ITaskManagerRepository _repository;

    public CreateTaskManagerCommandHandler(ITaskManagerRepository repository)
    {
        _repository = repository;
    }

    public Task<Guid> Handle(CreateTaskManagerCommand request, CancellationToken cancellationToken)
    {
        var taskManager = new TaskManagerAggregate(
            Guid.NewGuid(),
            request.Title,
            new Category(request.Category)
            );

        _repository.EmbodyAsync(taskManager);

        return Task.FromResult(Guid.NewGuid());
    }
}
