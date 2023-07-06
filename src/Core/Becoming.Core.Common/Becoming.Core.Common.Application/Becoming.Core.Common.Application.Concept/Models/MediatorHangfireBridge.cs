using MediatR;
using System.ComponentModel;

namespace Becoming.Core.Common.Application.Concept.Models;

public sealed class MediatorHangfireBridge
{
    private readonly IMediator _mediator;

    public MediatorHangfireBridge(IMediator mediator) => _mediator = mediator;

    [DisplayName("{0}")]
    public async Task Send(ICommand command) => await _mediator.Send(command);

    [DisplayName("{0}")]
    public async Task Publish(string jobName, INotification notification) => await _mediator.Publish(notification);
}
