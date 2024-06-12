using Becoming.Core.Common.Domain.Seedwork.Interfaces;
using Becoming.Core.TaskManager.Application.Root.Commands.Create;
using Becoming.Core.TaskManager.Domain.Root;

namespace Becoming.Core.TaskManager.Application;

public interface ITaskManagerFactory : IDomainEntityFactory
{
    TaskManagerRoot CreateTaskManager(CreateTaskManagerRequest dto);
}
