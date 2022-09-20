using Becoming.Core.Common.Seedwork.Models;

namespace Becoming.Core.TaskManager.Domain.Models;

public sealed class SummaryTask : AuditableEntity
{
    #region ctor
    public SummaryTask(
        Guid id,
        string title,
        string? description,
        DateTime startDate,
        bool isComplete,
        bool onlyDate = false
        ) : base(id)
    {
        Title = title;
        OnlyDate = onlyDate;
        Description = description;
        IsComplete = isComplete;
        StartDate = startDate;
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

}
