
namespace Becoming.Core.TaskManager.Infrastructure.Models;

public sealed class SummaryTaskSaveModel
{
    public Guid? GroupId { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public ICollection<SubtaskSaveModel>? Subtasks { get; set; }
    public bool IsActive { get; set; }
    public bool IsArchive { get; set; }
    public bool OnlyDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
