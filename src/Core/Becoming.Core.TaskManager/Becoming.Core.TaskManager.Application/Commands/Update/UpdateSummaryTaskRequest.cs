using Becoming.Core.Common.Abstractions.Interfaces;
using Becoming.Core.TaskManager.Domain.Models;
using FluentValidation;

namespace Becoming.Core.TaskManager.Application.Commands.Update;

public sealed record class UpdateSummaryTaskRequest : IDtoObject<SummaryTask>
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public bool OnlyDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public SummaryTask ToDomainModel()
    {
        return new SummaryTask(
            id: Id,
            title: Title,
            description: Description,
            startDate: StartDate,
            onlyDate: OnlyDate,
            endDate: EndDate,
            isComplete: default);
    }
}

sealed class UpdateTaskManagerRequestValidator : AbstractValidator<UpdateSummaryTaskRequest>
{
    public UpdateTaskManagerRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.StartDate)
            .NotEmpty()
            .NotNull();
    }
}
