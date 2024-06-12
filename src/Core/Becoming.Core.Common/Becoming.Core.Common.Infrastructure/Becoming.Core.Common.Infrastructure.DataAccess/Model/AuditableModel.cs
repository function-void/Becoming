namespace Becoming.Core.Common.Infrastructure.DataAccess.Model;

public abstract class AuditableModel : BaseModel, ISoftAuditable
{
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? LastModifiedAt { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public string CreatedBy { get; set; } = null!;
    public string? LastModifiedBy { get; set; }
    public string? DeletedBy { get; set; }
    public bool IsDeleted { get; set; }
}