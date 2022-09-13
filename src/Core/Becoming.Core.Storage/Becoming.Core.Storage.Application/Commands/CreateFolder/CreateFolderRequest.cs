using FluentValidation;

namespace Becoming.Core.Storage.Application.Commands.CreateFolder;

public sealed record class CreateFolderRequest(string Name, Guid BoundaryId);

public sealed class CreateFolderRequestValidator : AbstractValidator<CreateFolderRequest>
{
    public CreateFolderRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.BoundaryId)
            .NotEmpty()
            .NotNull();
    }
}