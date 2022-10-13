namespace Becoming.Core.Common.Seedwork.Interfaces;

public interface ISpecification<in T>
{
    bool IsSatisfied(T obj);
}