using System.Linq.Expressions;
using Becoming.Core.Common.Domain.Seedwork.Interfaces;

namespace Becoming.Core.Common.Domain.Seedwork;

public abstract class ExpressionSpecification<T> : ISpecification<T>
{
    private Func<T, bool>? _expressionFunc;
    private Func<T, bool> ExpressionFunc => _expressionFunc ??= Expression.Compile();

    protected ExpressionSpecification(Expression<Func<T, bool>> expression)
    {
        Expression = expression;
    }

    public Expression<Func<T, bool>> Expression { get; }

    public bool IsSatisfied(T obj)
    {
        var result = ExpressionFunc(obj);
        return result;
    }
}
