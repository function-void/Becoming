namespace Becoming.Core.Common.Seedwork.Models;

public abstract class AuditableEntity : Entity
{
    protected AuditableEntity(Guid id) : base(id) { }

    public DateTime CreatedAt { get; private set; }
    public DateTime? LastModifiedAt { get; private set; }
    public string CreatedBy { get; private set; } = null!;
    public string? LastModifiedBy { get; private set; }
}