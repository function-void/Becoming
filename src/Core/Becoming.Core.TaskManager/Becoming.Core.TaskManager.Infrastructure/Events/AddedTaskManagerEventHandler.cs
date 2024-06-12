using MediatR;
using Becoming.Core.TaskManager.Application.Root.Commands.Create;

namespace Becoming.Core.TaskManager.Infrastructure.Events;

sealed class AddedTaskManagerEventHandler : INotificationHandler<AddedTaskManagerEvent>
{
    public async Task Handle(AddedTaskManagerEvent notification, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }
}
