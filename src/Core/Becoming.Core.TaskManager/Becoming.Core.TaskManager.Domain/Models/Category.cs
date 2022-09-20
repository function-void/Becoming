using Becoming.Core.Common.Seedwork.Models;

namespace Becoming.Core.TaskManager.Domain.Models;

public sealed class Category : ValueObject
{
    public Category(string name)
    {
        Name = name;
    }

    public string Name { get; private set; } = null!;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
    }
}