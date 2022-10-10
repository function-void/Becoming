using MediatR;
using Hangfire;
using Becoming.Core.Common.Abstractions.CQRS.Interfaces;

namespace Becoming.Core.Common.Primitives.Extensions;

public static class MediatorExtensions
{
    public static void Enqueue(this IMediator mediator, ICommand commnad)
    {
        var client = new BackgroundJobClient();
        client.Enqueue<MediatorHangfireBridge>(bridge => bridge.Send(commnad));
    }

    public static void Enqueue(this IMediator mediator, INotification notification)
    {
        var client = new BackgroundJobClient();
        client.Enqueue<MediatorHangfireBridge>(bridge => bridge.Publish(notification));
    }
}

public sealed class MediatorHangfireBridge
{
    private readonly IMediator _mediator;

    public MediatorHangfireBridge(IMediator mediator) => _mediator = mediator;

    public async Task Send(ICommand command) => await _mediator.Send(command);

    public async Task Publish(INotification notification) => await _mediator.Publish(notification);
}
