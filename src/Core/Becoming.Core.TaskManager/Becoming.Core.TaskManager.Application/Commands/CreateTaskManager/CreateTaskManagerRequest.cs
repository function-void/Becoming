using FluentValidation;

namespace Becoming.Core.TaskManager.Application.Commands.CreateTaskManager;

public sealed record class CreateTaskManagerRequest(string Title, string Category);

public sealed class CreateTaskManagerRequestValidator : AbstractValidator<CreateTaskManagerRequest>
{
    public CreateTaskManagerRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Category)
            .NotEmpty()
            .NotNull();
    }
}
