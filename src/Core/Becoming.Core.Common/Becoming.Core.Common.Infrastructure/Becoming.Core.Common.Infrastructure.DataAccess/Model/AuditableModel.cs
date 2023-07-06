namespace Becoming.Core.Common.Infrastructure.DataAccess.Model;

public abstract class AuditableModel : BaseModel, ISoftAuditable
{
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public string CreatedBy { get; set; } = null!;
    public string? LastModifiedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
    public bool IsDeleted { get; set; }
}
