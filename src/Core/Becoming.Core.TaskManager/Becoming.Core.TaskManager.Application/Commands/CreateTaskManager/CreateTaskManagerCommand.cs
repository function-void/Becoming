using Becoming.Core.Common.Abstractions.CQRS;
using Becoming.Core.TaskManager.Domain.Repositories;

namespace Becoming.Core.TaskManager.Application.Commands.CreateTaskManager;

public sealed record class CreateTaskManagerCommand(CreateTaskManagerRequest Dto) : ICommand<Guid>;

public sealed class CreateTaskManagerCommandHandler : ICommandHandler<CreateTaskManagerCommand, Guid>
{
    private readonly ICommandTaskManagerRepository _repository;

    public CreateTaskManagerCommandHandler(
        ICommandTaskManagerRepository repository
        )
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateTaskManagerCommand command, CancellationToken cancellationToken)
    {
        var taskManager = command.Dto.ToDomainModel();

        return await _repository.EmbodyAsync(taskManager, cancellationToken);
    }
}
