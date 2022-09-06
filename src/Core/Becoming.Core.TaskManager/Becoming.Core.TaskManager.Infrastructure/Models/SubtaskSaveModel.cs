
namespace Becoming.Core.TaskManager.Infrastructure.Models;

public class SubtaskSaveModel
{
    public string? Description { get; set; }
    public SummaryTaskSaveModel SummaryTask { get; set; } = null!;
    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }
}
