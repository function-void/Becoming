using Becoming.Core.Common.Seedwork.Models;
using Becoming.Core.TaskManager.Domain.Exceptions;
using Becoming.Core.TaskManager.Domain.Exceptions.Errors;

namespace Becoming.Core.TaskManager.Domain.Models;

public sealed class SummaryTask : Entity
{
    #region ctor
    public SummaryTask(
        Content content,
        DateTime startDate,
        bool onlyDate = default) : base(Guid.NewGuid())
    {
        Content = content;
        OnlyDate = onlyDate;
        StartDate = startDate;
    }

    public SummaryTask(
       Guid id,
       Content content,
       DateTime startDate,
       DateTime? endDate,
       bool onlyDate,
       bool isComplete) : base(id)
    {
        Content = content;
        StartDate = startDate;
        EndDate = endDate;
        OnlyDate = onlyDate;
        IsComplete = isComplete;
    }
    #endregion

    #region property
    public Content Content { get; private set; }
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
            throw new TaskManagerDomainException(DomainExceptionMessages.DeadlinesNotValid);

        IsComplete = true;
    }

    private static DateTime GetEndDateWhenCompletedIfNotSpecified() => DateTime.UtcNow;
}
