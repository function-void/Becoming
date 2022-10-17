using MediatR;
using Becoming.Core.Common.Abstractions.CQRS.Interfaces;
using Becoming.Core.Common.Primitives.Exceptions;
using Becoming.Core.TaskManager.Domain.Repositories;

namespace Becoming.Core.TaskManager.Application.Commands.Update;

public sealed record class UpdateSummaryTaskCommand(Guid TaskManagerId, Guid SummaryTaskId, UpdateSummaryTaskRequest Dto)
    : ICommand<Unit>;

sealed class UpdateSummaryTaskCommandHandler : ICommandHandler<UpdateSummaryTaskCommand, Unit>
{
    private readonly ITaskManagerRepository _repository;

    public UpdateSummaryTaskCommandHandler(ITaskManagerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateSummaryTaskCommand command, CancellationToken cancellationToken)
    {
        if (command.SummaryTaskId != command.TaskManagerId) throw new BadRequestException();

        var summaryTask = command.Dto.ToDomainModel();

        if (command.Dto.EndDate.HasValue && command.Dto.EndDate.Value != default)
            summaryTask.Complete(command.Dto.EndDate);

        var taskManager = await _repository.GetByIdAsync(command.TaskManagerId);

        taskManager.UpdateSummaryTask(summaryTask);

        await _repository.UpdateAsync(taskManager);

        return Unit.Value;
    }
}
