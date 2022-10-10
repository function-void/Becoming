namespace Becoming.Core.Common.Abstractions.Interfaces;

public interface ISpecification<in T>
{
    bool IsSatisfied(T obj);
}
