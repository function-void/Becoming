using Becoming.Core.Common.Seedwork.Models;
using Becoming.Core.TaskManager.Domain.Events;
using Becoming.Core.TaskManager.Domain.Exceptions;

namespace Becoming.Core.TaskManager.Domain.Models;

public sealed class TaskManagerAggregate : AggregateRoot
{
    private readonly List<SummaryTask> _summaryTasks = new();
    private readonly List<Subtask> _subtasks = new();

    #region ctor
    public TaskManagerAggregate(string title, Category category) : base(Guid.NewGuid())
    {
        Title = title;
        Category = category;
        IsFinalize = default;

        base.PublishDomainEvent(new AddTaskManagerEvent(
            eventId: Guid.NewGuid(),
            aggregateId: this.Id,
            createAt: DateTime.UtcNow));
    }
    #endregion

    #region property
    public Category Category { get; private set; }
    public string Title { get; private set; }
    public bool IsFinalize { get; private set; }
    public IReadOnlyCollection<SummaryTask> SummaryTasks => _summaryTasks.AsReadOnly();
    public IReadOnlyCollection<Subtask> Subtasks => _subtasks.AsReadOnly();
    #endregion

    public void CreateSubtask(Guid summartTaskId, Content content)
    {
        if (_summaryTasks.Any(x => x.Id != summartTaskId)) throw new TaskManagerDomainException();

        _subtasks.Add(new Subtask(
            id: Guid.NewGuid(),
            summaryTaskId: summartTaskId,
            title: content.Title,
            description: content.Description
            ));
    }

    public void CreateSummaryTask(Guid id, Content content, DateTime startDate, bool onlyDate = false)
    {
        if (_summaryTasks.Any(x => x.Id == id)) throw new TaskManagerDomainException();

        _summaryTasks.Add(new SummaryTask(
            id: id,
            startDate: startDate,
            onlyDate: onlyDate,
            title: content.Title ?? string.Empty,
            description: content.Description ?? string.Empty
            ));
    }

    public void Complete()
    {
        if (IsFinalize) throw new TaskManagerDomainException();

        IsFinalize = !IsFinalize;

        _subtasks.ForEach(x => x.Complete());
        _summaryTasks.ForEach(x => x.Complete());
    }

    public void PerformTask(object task)
    {

    }
}