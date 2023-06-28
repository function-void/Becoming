using Becoming.Core.Common.Domain.Seedwork;

namespace Becoming.Core.TaskManager.Domain.Models;

public sealed class Subtask : Entity
{
    #region ctor
    internal Subtask(
        Guid id,
        Guid summaryTaskId,
        Content content,
        bool isComplete = default) : base(id)
    {
        Content = content;
        SummaryTaskId = summaryTaskId;
        IsComplete = isComplete;
    }
    #endregion

    #region property
    public Content Content { get; private set; }
    public Guid SummaryTaskId { get; private set; }
    public bool IsComplete { get; private set; }
    #endregion

    public void Complete()
    {
        IsComplete = true;
    }
}
