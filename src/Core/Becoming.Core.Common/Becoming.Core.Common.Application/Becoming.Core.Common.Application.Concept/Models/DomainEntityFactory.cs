using Becoming.Core.Common.Domain.Seedwork.Interfaces;

namespace Becoming.Core.Common.Application.Concept.Models;

public abstract class DomainEntityFactory : IDomainEntityFactory
{
    protected DomainEntityFactory(string permissionKey)
    {
        PermissionKey = permissionKey ??= nameof(DomainEntityFactory);
    }

    public string PermissionKey { get; private init; }

    public override int GetHashCode()
    {
        return HashCode.Combine(PermissionKey);
    }
}