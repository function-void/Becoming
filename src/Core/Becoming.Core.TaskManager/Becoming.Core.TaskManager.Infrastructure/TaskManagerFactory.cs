using Becoming.Core.Common.Application.Concept.Models;
using Becoming.Core.TaskManager.Application;
using Becoming.Core.TaskManager.Application.Commands.Create;
using Becoming.Core.TaskManager.Domain.Models;

namespace Becoming.Core.TaskManager.Infrastructure;

public sealed class TaskManagerFactory : DomainEntityFactory, ITaskManagerFactory
{
    public TaskManagerFactory() : base(nameof(TaskManagerFactory)) { }

    public TaskManagerAggregate CreateTaskManager(CreateTaskManagerRequest dto)
    {
        return new TaskManagerAggregate(dto.Title, Category.Create(dto.CategoryText));
    }
}
