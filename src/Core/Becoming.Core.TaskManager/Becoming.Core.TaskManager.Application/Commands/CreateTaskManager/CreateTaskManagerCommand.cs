using Becoming.Core.Common.Abstractions.CQRS;
using Becoming.Core.Common.Abstractions.CQRS.Interfaces;
using Becoming.Core.TaskManager.Domain.Repositories;

namespace Becoming.Core.TaskManager.Application.Commands.CreateTaskManager;

public sealed record class CreateTaskManagerCommand(CreateTaskManagerRequest Dto)
    : CommandWithDto<CreateTaskManagerRequest, Guid>(Dto);

sealed class CreateTaskManagerCommandHandler : ICommandHandler<CreateTaskManagerCommand, Guid>
{
    private readonly ITaskManagerRepository _repository;

    public CreateTaskManagerCommandHandler(
        ITaskManagerRepository repository
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
