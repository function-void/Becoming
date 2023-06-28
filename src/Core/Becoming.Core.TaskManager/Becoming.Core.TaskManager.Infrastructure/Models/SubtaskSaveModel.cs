using Becoming.Core.Common.Infrastructure.DataAccess.Model;

namespace Becoming.Core.TaskManager.Infrastructure.Models;

public sealed class SubtaskSaveModel : BaseModel
{
    public string? Description { get; set; }
    public SummaryTaskSaveModel SummaryTask { get; set; } = null!;
    public bool IsComplete { get; set; }
    public bool IsArchive { get; set; }
}
