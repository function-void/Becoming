using Becoming.Core.Common.Seedwork.Models;
using Becoming.Core.TaskManager.Domain.Exceptions;

namespace Becoming.Core.TaskManager.Domain.Models;

public sealed class SummaryTask : Entity
{
    #region ctor
    public SummaryTask(
        string title,
        DateTime startDate,
        string? description = default,
        bool onlyDate = default) : base(Guid.NewGuid())
    {
        Title = title;
        Description = description;
        OnlyDate = onlyDate;
        StartDate = startDate;
    }

    public SummaryTask(
       Guid id,
       string title,
       DateTime startDate,
       DateTime? endDate,
       string? description,
       bool onlyDate,
       bool isComplete) : base(id)
    {
        Title = title;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        OnlyDate = onlyDate;
        IsComplete = isComplete;
    }
    #endregion

    #region property
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public bool IsComplete { get; private set; }
    public bool OnlyDate { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    #endregion

    public void Complete(DateTime? endDate = default)
    {
        if (endDate is null || endDate!.Value == default)
            endDate = GetEndDateWhenCompletedIfNotSpecified();

        if (endDate.HasValue && endDate >= StartDate)
            throw new TaskManagerDomainException();

        IsComplete = true;
    }

    private static DateTime GetEndDateWhenCompletedIfNotSpecified() => DateTime.UtcNow;
}
