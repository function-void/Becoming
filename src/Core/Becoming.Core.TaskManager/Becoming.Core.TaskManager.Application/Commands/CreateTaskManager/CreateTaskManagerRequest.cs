using FluentValidation;
using Becoming.Core.TaskManager.Domain.Models;
using Becoming.Core.Common.Abstractions.Interfaces;

namespace Becoming.Core.TaskManager.Application.Commands.CreateTaskManager;

public sealed class CreateTaskManagerRequest : IDtoObject<TaskManagerAggregate>
{
    public string Title { get; set; } = null!;
    public string Category { get; set; } = null!;

    public TaskManagerAggregate ToDomainModel()
    {
        var taskManager = new TaskManagerAggregate(Guid.NewGuid(), Title, new Category(Category));
        return taskManager;
    }
};

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
