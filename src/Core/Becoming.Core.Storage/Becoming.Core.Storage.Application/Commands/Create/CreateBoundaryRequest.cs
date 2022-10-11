using FluentValidation;

namespace Becoming.Core.Storage.Application.Commands.Create;

public sealed record class CreateTaskManagerRequest(string Name, string Category);

public sealed class CreateTaskManagerRequestValidator : AbstractValidator<CreateTaskManagerRequest>
{
    public CreateTaskManagerRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Category)
            .NotEmpty()
            .NotNull();
    }
}
