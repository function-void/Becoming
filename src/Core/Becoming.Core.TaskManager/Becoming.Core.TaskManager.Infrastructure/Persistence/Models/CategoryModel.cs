namespace Becoming.Core.TaskManager.Infrastructure.Persistence.Models;

public sealed class CategoryModel
{
    public string Name { get; set; } = null!;
    public TaskManagerSaveModel TaskManager { get; set; } = null!;
}