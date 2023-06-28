namespace Becoming.Core.Common.Domain.Seedwork.Interfaces;

public interface ISpecification<in T>
{
    bool IsSatisfied(T obj);
}