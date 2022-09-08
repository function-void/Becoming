namespace Becoming.Core.TaskManager.Application.Queries.GetTaskManager;

public sealed record class TaskManagerResponse(Guid TaskManagerId, string Title)
{
    public string CategoryName { get; set; } = null!;
}
