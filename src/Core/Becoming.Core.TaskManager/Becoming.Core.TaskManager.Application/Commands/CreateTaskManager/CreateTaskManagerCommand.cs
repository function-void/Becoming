using Becoming.Core.Common.Abstractions.CQRS;
using Becoming.Core.TaskManager.Domain.Repositories;
using MediatR;

namespace Becoming.Core.TaskManager.Application.Commands.CreateTaskManager;

public sealed record class CreateTaskManagerCommand(CreateTaskManagerRequest Dto) : ICommand<Guid>;

public sealed class CreateTaskManagerCommandHandler : ICommandHandler<CreateTaskManagerCommand, Guid>
{
    private readonly ITaskManagerRepository _repository;

    public CreateTaskManagerCommandHandler(
        ITaskManagerRepository repository
        )
    {
        _repository = repository;
    }

    public Task<Guid> Handle(CreateTaskManagerCommand command, CancellationToken cancellationToken)
    {
        var taskManager = command.Dto.ToDomainModel();

        _repository.EmbodyAsync(taskManager, cancellationToken);

        return Task.FromResult(Guid.NewGuid());
    }
}
