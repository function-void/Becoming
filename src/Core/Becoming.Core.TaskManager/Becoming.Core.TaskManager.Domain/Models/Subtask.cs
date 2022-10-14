using Becoming.Core.Common.Seedwork.Models;
using Becoming.Core.TaskManager.Domain.Exceptions;

namespace Becoming.Core.TaskManager.Domain.Models;

public sealed class Subtask : Entity
{
    #region ctor
    internal Subtask(
        Guid id,
        Guid summaryTaskId,
        string? title = default,
        string? description = default,
        bool isComplete = default) : base(id)
    {
        Title = title;
        SummaryTaskId = summaryTaskId;
        Description = description;
        IsComplete = isComplete;
    }
    #endregion

    #region property
    public string? Title { get; private set; }
    public Guid SummaryTaskId { get; private set; }
    public string? Description { get; private set; }
    public bool IsComplete { get; private set; }
    #endregion

    public void Complete()
    {
        IsComplete = true;
    }
}
