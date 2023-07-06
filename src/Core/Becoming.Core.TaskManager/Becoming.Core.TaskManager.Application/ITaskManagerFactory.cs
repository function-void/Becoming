using Becoming.Core.Common.Domain.Seedwork.Interfaces;
using Becoming.Core.TaskManager.Application.Commands.Create;
using Becoming.Core.TaskManager.Domain.Models;

namespace Becoming.Core.TaskManager.Application;

public interface ITaskManagerFactory : IDomainEntityFactory
{
    TaskManagerAggregate CreateTaskManager(CreateTaskManagerRequest dto);
}
