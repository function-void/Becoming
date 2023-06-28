using Becoming.Core.Common.Application.Concept;

namespace Becoming.Core.Storage.Application.Commands.Create;

public sealed record class CreateFolderCommand(string Name) : ICommand<Guid>;

public sealed class CreateFolderCommandHandler : ICommandHandler<CreateFolderCommand, Guid>
{
    public Task<Guid> Handle(CreateFolderCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
