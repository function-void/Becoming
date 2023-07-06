using FluentValidation;

namespace Becoming.Core.TaskManager.Application.Commands.Create;

public sealed record class CreateTaskManagerRequest
{
    public string Title { get; set; } = null!;
    public string CategoryText { get; set; } = null!;
}

sealed class CreateTaskManagerRequestValidator : AbstractValidator<CreateTaskManagerRequest>
{
    public CreateTaskManagerRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.CategoryText)
            .NotEmpty()
            .NotNull();
    }
}
