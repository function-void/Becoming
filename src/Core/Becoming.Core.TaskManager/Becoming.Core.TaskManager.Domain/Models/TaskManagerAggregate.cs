using Becoming.Core.Common.Primitives.Models;
using Becoming.Core.Common.Seedwork.Models;

namespace Becoming.Core.TaskManager.Domain.Models;

public sealed class TaskManagerAggregate : Entity
{
    public TaskManagerAggregate(Guid id, string title, Category category) : base(id)
    {
        Title = title;
        Category = category;
    }

    public Category Category { get; private set; }
    public string Title { get; private set; }
}

public class Task : AuditableEntity
{
    public Task(Guid id, string title) : base(id)
    {
        Title = title;
    }

    public string Title { get; private set; }
}

public class Subtask
{

}

public sealed class Category
{
    public string Name { get; set; } = null!;
}