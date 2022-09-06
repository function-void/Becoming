
namespace Becoming.Core.TaskManager.Infrastructure.Models;

public sealed class TaskManagerSaveModel
{
    public CategoryModel? Category { get; set; }
    public string Title { get; set; } = null!;
    public bool IsActive { get; set; }
    public bool IsArchive { get; set; }
    public List<SummaryTaskSaveModel> SummaryTasks { get; set; } = new();
}