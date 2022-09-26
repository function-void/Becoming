using Becoming.Core.Common.Seedwork.Models;
using Becoming.Core.TaskManager.Domain.Exceptions;
using Becoming.Core.TaskManager.Domain.Exceptions.Errors;

namespace Becoming.Core.TaskManager.Domain.Models;

public sealed class Category : ValueObject
{
    public const int MaxLength = 50;

    private Category(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public static Category Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new CategoryDomainException(DomainExceptionMessages.CategoryIsEmpty);
        if (name.Length > MaxLength) throw new CategoryDomainException(DomainExceptionMessages.CategoryIsMaxLength);

        return new Category(name);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
    }
}