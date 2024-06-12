namespace Becoming.Core.TaskManager.Application.Root.Queries;

public sealed record class TaskManagerResponse(Guid TaskManagerId, string Title)
{
    public string CategoryName { get; set; } = null!;
}
