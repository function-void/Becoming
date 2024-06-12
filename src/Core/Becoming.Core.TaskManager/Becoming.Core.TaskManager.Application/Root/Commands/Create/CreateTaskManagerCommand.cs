using Becoming.Core.Common.Application.Concept;
using Becoming.Core.TaskManager.Domain.Root;

namespace Becoming.Core.TaskManager.Application.Root.Commands.Create;

public sealed record class CreateTaskManagerCommand(CreateTaskManagerRequest Dto) : ICommandWithDto<CreateTaskManagerRequest, Guid>;

sealed class CreateTaskManagerCommandHandler : ICommandHandler<CreateTaskManagerCommand, Guid>
{
    private readonly ITaskManagerFactory _factory;
    private readonly IProjector _projector;
    private readonly ITaskManagerRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTaskManagerCommandHandler(
        ITaskManagerFactory factory,
        IProjector projector,
        ITaskManagerRepository repository,
        IUnitOfWork unitOfWork)
    {
        _factory = factory;
        _projector = projector;
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateTaskManagerCommand command, CancellationToken cancellationToken)
    {
        var taskManager = _factory.CreateTaskManager(command.Dto);

        var newEvent = new AddedTaskManagerEvent(
            eventId: Guid.NewGuid(),
            aggregateId: taskManager.Id);

        await _repository.CreateAsync(taskManager, cancellationToken);

        taskManager.PublishDomainEvent(newEvent);
        _projector.DispatchEvents(taskManager);

        await _unitOfWork.SaveChangesAsync();

        return taskManager.Id;
    }
}
