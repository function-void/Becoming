using Becoming.Core.Common.Abstractions.CQRS.Interfaces;

namespace Becoming.Core.Storage.Application.Commands.Create;

public sealed record class CreateBoundaryCommand(string Name, string Category) : ICommand<Guid>;

public sealed class CreateBoundaryCommandHandler : ICommandHandler<CreateBoundaryCommand, Guid>
{
    public Task<Guid> Handle(CreateBoundaryCommand request, CancellationToken cancellationToken)
    {
        var boundary = new BoundaryAggregate(Guid.NewGuid(), request.Name, request.Category);

        return Task.FromResult(boundary.Id);
    }
}

public sealed class BoundaryAggregate
{
    public BoundaryAggregate(Guid id, string name, string category)
    {
        Id = id;
        Name = name;
        Category = category;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Category { get; private set; }
}
