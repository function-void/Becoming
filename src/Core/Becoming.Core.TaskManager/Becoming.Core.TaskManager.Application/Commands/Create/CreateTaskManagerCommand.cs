using Becoming.Core.Common.Application.Concept;
using Becoming.Core.TaskManager.Domain.Repositories;

namespace Becoming.Core.TaskManager.Application.Commands.Create;

public sealed class CreateTaskManagerCommand : CommandWithDto<CreateTaskManagerRequest, Guid> { }

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
