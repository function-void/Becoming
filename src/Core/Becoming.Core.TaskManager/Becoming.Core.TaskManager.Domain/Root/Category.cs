using Becoming.Core.Common.Domain.Seedwork;
using Becoming.Core.TaskManager.Domain.Root.Exceptions;
using Becoming.Core.TaskManager.Domain.Root.Exceptions.Resources;

namespace Becoming.Core.TaskManager.Domain.Root;

public sealed class Category : ValueObject
{
    public const int MaxLength = 50;

    private Category(string name) => Name = name;

    public string Name { get; }

    public static Category Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new CategoryDomainException(DomainExceptionMessages.CategoryIsEmpty);
        if (name.Length > MaxLength) throw new CategoryDomainException(DomainExceptionMessages.CategoryLengthIncorrect);

        return new Category(name);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
    }
}