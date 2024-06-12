using Becoming.Core.TaskManager.Application;
using Becoming.Core.Common.Application.Concept.Models;
using Becoming.Core.TaskManager.Application.Root.Commands.Create;
using Becoming.Core.TaskManager.Domain.Root;

namespace Becoming.Core.TaskManager.Infrastructure;

internal sealed class TaskManagerFactory : DomainEntityFactory, ITaskManagerFactory
{
    public TaskManagerFactory() : base(nameof(TaskManagerFactory)) { }

    public TaskManagerRoot CreateTaskManager(CreateTaskManagerRequest dto)
    {
        return new TaskManagerRoot(dto.Title, Category.Create(dto.CategoryText));
    }
}
