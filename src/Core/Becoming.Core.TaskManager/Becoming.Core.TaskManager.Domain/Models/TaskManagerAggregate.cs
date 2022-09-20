using Becoming.Core.Common.Seedwork.Models;

namespace Becoming.Core.TaskManager.Domain.Models;

public sealed class TaskManagerAggregate : AggregateRoot
{
    private readonly List<SummaryTask> _summaryTasks = new();
    private readonly List<Subtask> _subtasks = new();

    #region ctor
    public TaskManagerAggregate(Guid id, string title, Category category) : base(id)
    {
        Title = title;
        Category = category;
    }
    #endregion

    #region property
    public Category Category { get; private set; }
    public string Title { get; private set; }
    public IReadOnlyCollection<SummaryTask> SummaryTasks => _summaryTasks.AsReadOnly();
    public IReadOnlyCollection<Subtask> Subtasks => _subtasks.AsReadOnly();
    #endregion
}