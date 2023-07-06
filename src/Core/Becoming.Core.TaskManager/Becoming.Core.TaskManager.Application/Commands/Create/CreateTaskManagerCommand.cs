using Becoming.Core.Common.Application.Concept;
using Becoming.Core.TaskManager.Application.Events;
using Becoming.Core.TaskManager.Domain.Repositories;
using System.Transactions;

namespace Becoming.Core.TaskManager.Application.Commands.Create;

public sealed record class CreateTaskManagerCommand(CreateTaskManagerRequest Dto) : ICommandWithDto<CreateTaskManagerRequest, Guid>;

sealed class CreateTaskManagerCommandHandler : ICommandHandler<CreateTaskManagerCommand, Guid>
{
    private readonly ITaskManagerRepository _repository;
    private readonly ITaskManagerFactory _factory;
    private readonly IProjector _projector;

    public CreateTaskManagerCommandHandler(
        ITaskManagerRepository repository,
        ITaskManagerFactory factory,
        IProjector projector)
    {
        _repository = repository;
        _factory = factory;
        _projector = projector;
    }

    public async Task<Guid> Handle(CreateTaskManagerCommand command, CancellationToken cancellationToken)
    {
        var taskManager = _factory.CreateTaskManager(command.Dto);

        var newEvent = new AddTaskManagerEvent(
            eventId: Guid.NewGuid(),
            aggregateId: taskManager.Id,
            createAt: DateTime.UtcNow);

        using TransactionScope transaction = new(TransactionScopeOption.Required,
               new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted },
               TransactionScopeAsyncFlowOption.Enabled);

        taskManager.PublishDomainEvent(newEvent);
        await _repository.EmbodyAsync(taskManager, cancellationToken);

        taskManager.DispatchEvents(_projector);

        transaction.Complete();

        return taskManager.Id;
    }
}
