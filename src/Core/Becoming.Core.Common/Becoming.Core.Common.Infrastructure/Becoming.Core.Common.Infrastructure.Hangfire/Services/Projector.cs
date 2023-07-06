using Hangfire;
using Becoming.Core.Common.Application.Concept;
using Becoming.Core.Common.Application.Concept.Models;

namespace Becoming.Core.Common.Infrastructure.Hangfire.Services;

public class Projector : IProjector
{
    public void Enqueue(ICommand commnad)
    {
        var client = new BackgroundJobClient();
        client.Enqueue<MediatorHangfireBridge>(bridge => bridge.Send(commnad));
    }

    public void Enqueue(IEvent @event)
    {
        var client = new BackgroundJobClient();
        client.Enqueue<MediatorHangfireBridge>(bridge => bridge.Publish(@event.Message, @event));
    }
}
