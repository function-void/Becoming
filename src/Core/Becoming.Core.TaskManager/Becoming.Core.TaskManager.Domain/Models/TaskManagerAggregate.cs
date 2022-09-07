using Becoming.Core.Common.Primitives.Models;
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

public sealed class Category : ValueObject
{
    public Category(string name)
    {
        Name = name;
    }

    public string Name { get; private set; } = null!;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
    }
}