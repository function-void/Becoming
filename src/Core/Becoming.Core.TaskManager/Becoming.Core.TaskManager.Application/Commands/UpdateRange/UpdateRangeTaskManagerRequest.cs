using FluentValidation;

namespace Becoming.Core.TaskManager.Application.Commands.UpdateRange;

public sealed record class UpdateRangeTaskManagerItem
{
    public Guid TaskManagerId { get; set; }
    public string Title { get; set; } = null!;
    public string CategoryText { get; set; } = null!;
}

public sealed record class UpdateRangeTaskManagerRequest
{
    public List<UpdateRangeTaskManagerItem> Updates { get; set; } = null!;
}

sealed class UpdateRangeTaskManagerRequestValidator : AbstractValidator<UpdateRangeTaskManagerRequest>
{
    public UpdateRangeTaskManagerRequestValidator()
    {
        RuleFor(x => x.Updates)
            .NotNull()
            .NotEmpty();
    }
}