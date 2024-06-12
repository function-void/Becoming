using FluentValidation;
using Becoming.Core.Common.Application.Concept;
using Becoming.Core.TaskManager.Domain.Root;

namespace Becoming.Core.TaskManager.Application.Root.Commands.Update;

public sealed record class UpdateSummaryTaskRequest : IDataTransferObject<SummaryTask>
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public Guid? StorageId { get; set; }
    public bool OnlyDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public SummaryTask ToDomainModel()
    {
        return new SummaryTask(
            id: Id,
            Content.Create(Title ?? string.Empty, Description ?? string.Empty, StorageId),
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
