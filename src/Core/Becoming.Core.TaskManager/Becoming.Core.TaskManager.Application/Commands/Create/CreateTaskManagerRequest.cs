using FluentValidation;
using Becoming.Core.TaskManager.Domain.Models;
using Becoming.Core.Common.Application.Concept;

namespace Becoming.Core.TaskManager.Application.Commands.Create;

public sealed record class CreateTaskManagerRequest : IDtoObject<TaskManagerAggregate>
{
    public string Title { get; set; } = null!;
    public string CategoryText { get; set; } = null!;

    public TaskManagerAggregate ToDomainModel()
    {
        return new TaskManagerAggregate(Title, Category.Create(CategoryText));
    }
};

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
