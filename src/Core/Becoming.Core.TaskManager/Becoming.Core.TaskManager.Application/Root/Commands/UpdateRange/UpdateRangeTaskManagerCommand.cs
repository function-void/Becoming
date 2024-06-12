using MediatR;
using Becoming.Core.Common.Application.Concept;

namespace Becoming.Core.TaskManager.Application.Root.Commands.UpdateRange;

public sealed record class UpdateRangeTaskManagerCommand(UpdateRangeTaskManagerRequest Dto)  : ICommand<Unit>;

sealed class UpdateRangeTaskManagerCommandHandler : ICommandHandler<UpdateRangeTaskManagerCommand, Unit>
{
    public Task<Unit> Handle(UpdateRangeTaskManagerCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
