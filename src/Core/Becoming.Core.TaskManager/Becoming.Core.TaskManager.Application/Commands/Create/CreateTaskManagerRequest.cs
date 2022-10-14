﻿using FluentValidation;
using Becoming.Core.TaskManager.Domain.Models;
using Becoming.Core.Common.Abstractions.Interfaces;

namespace Becoming.Core.TaskManager.Application.Commands.Create;

public sealed record class CreateTaskManagerRequest : IDtoObject<TaskManagerAggregate>
{
    public string Title { get; set; } = null!;
    public string CategoryText { get; set; } = null!;

    public TaskManagerAggregate ToDomainModel()
    {
        var taskManager = new TaskManagerAggregate(Guid.NewGuid(), Title, Category.Create(CategoryText));
        return taskManager;
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