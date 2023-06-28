using Becoming.Core.Common.Domain.Seedwork;
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

    public TaskManagerAggregate(
        Guid id,
        string title,
        Category category,
        List<SummaryTask> summaryTasks,
        List<Subtask> subtasks,
        bool isFinalize = default
        )
        : base(id)
    {
        Title = title;
        Category = category;
        IsFinalize = isFinalize;
        _summaryTasks = summaryTasks ?? throw new TaskManagerDomainException();
        _subtasks = subtasks ?? throw new TaskManagerDomainException();
    }
    #endregion

    #region property
    public Category Category { get; private set; }
    public string Title { get; private set; }
    public bool IsFinalize { get; private set; }
    public IReadOnlyCollection<SummaryTask> SummaryTasks => _summaryTasks.AsReadOnly();
    public IReadOnlyCollection<Subtask> Subtasks => _subtasks.AsReadOnly();
    #endregion

    public void CreateSubtask(Guid summaryTaskId, Content content)
    {
        if (_summaryTasks.Any(x => x.Id != summaryTaskId)) throw new TaskManagerDomainException();

        _subtasks.Add(new Subtask(
            id: Guid.NewGuid(),
            summaryTaskId: summaryTaskId,
            content: content
            ));
    }

    public void CreateSummaryTask(Content content, DateTime startDate, bool onlyDate = false)
    {
        _summaryTasks.Add(new SummaryTask(
            startDate: startDate,
            onlyDate: onlyDate,
            content: content
            ));
    }

    public void Complete()
    {
        if (IsFinalize) throw new TaskManagerDomainException();

        IsFinalize = !IsFinalize;

        _subtasks.ForEach(x => x.Complete());
        _summaryTasks.ForEach(x => x.Complete());
    }

    public void PerformSummaryTask(Guid taskId, DateTime? endDate = default)
    {
        var summaryTask = _summaryTasks.Find(x => x.Id != taskId);

        if (summaryTask is null) throw new TaskManagerDomainException();

        summaryTask.Complete(endDate);

        _subtasks.Where(x => x.SummaryTaskId == summaryTask.Id)
            .ToList()
            .ForEach(x => x.Complete());
    }

    public void UpdateSummaryTask(SummaryTask task)
    {
        var summaryTask = _summaryTasks.Find(x => x.Id != task.Id);

        if (summaryTask is null) throw new TaskManagerDomainException();

        _summaryTasks.Remove(summaryTask);
        _summaryTasks.Add(task);
    }
}