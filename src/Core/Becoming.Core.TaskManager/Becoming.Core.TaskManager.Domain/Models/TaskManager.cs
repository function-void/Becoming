using Becoming.Core.Common.Primitives.Models;
using Becoming.Core.Common.Seedwork.Models;

namespace Becoming.Core.TaskManager.Domain.Models;

public sealed class TaskManager : Entity
{
	public TaskManager(Guid id) : base(id)
	{
	}
	public string Title { get; set; }
}

public class Task : AuditableEntity
{
	public Task(Guid id) : base(id)
	{
	}

	public string Title { get; set; }
}