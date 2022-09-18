namespace Becoming.Core.Common.Primitives.Models;

public interface ISpecification<in T>
{
    bool IsSatisfied(T obj);
}
