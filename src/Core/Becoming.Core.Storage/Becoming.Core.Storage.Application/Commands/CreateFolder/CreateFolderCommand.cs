using Becoming.Core.Common.Abstractions.CQRS.Interfaces;

namespace Becoming.Core.Storage.Application.Commands.CreateFolder;

public sealed record class CreateFolderCommand(string Name) : ICommand<Guid>;

public sealed class CreateFolderCommandHandler : ICommandHandler<CreateFolderCommand, Guid>
{
    public Task<Guid> Handle(CreateFolderCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
