namespace Becoming.Core.Common.Infrastructure.Shared;

public abstract class AuditableModel : BaseModel
{
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public string CreatedBy { get; set; } = null!;
    public string? LastModifiedBy { get; set; }
}
