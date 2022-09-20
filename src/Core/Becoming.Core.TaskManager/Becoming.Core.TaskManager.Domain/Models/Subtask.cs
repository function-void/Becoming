using Becoming.Core.Common.Seedwork.Models;

namespace Becoming.Core.TaskManager.Domain.Models;

public sealed class Subtask : Entity
{
    #region ctor
    internal protected Subtask(
        Guid id,
        Guid summaryTaskId,
        string? description,
        bool isComplete) : base(id)
    {
        SummaryTaskId = summaryTaskId;
        Description = description;
        IsComplete = isComplete;
    }
    #endregion

    #region property
    public Guid SummaryTaskId { get; private set; }
    public string? Description { get; private set; }
    public bool IsComplete { get; private set; }
    #endregion
}
