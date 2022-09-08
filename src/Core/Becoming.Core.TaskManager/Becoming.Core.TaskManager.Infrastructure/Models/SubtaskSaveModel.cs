
namespace Becoming.Core.TaskManager.Infrastructure.Models;

public sealed class SubtaskSaveModel
{
    public string? Description { get; set; }
    public SummaryTaskSaveModel SummaryTask { get; set; } = null!;
    public bool IsComplete { get; set; }
    public bool IsArchive { get; set; }
}
