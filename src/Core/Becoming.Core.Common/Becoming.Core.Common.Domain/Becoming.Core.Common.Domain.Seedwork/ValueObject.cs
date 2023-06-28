namespace Becoming.Core.Common.Domain.Seedwork;

public abstract class ValueObject
{
    protected static bool EqualOperator(ValueObject left, ValueObject right)
    {
        // (true ^ true = false)
        // (false ^ false = false)
        // (true ^ false = true)
        // (false ^ false = true)
        if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null)) return false;

        return ReferenceEquals(left, null) || left.Equals(right);
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType()) return false;

        var other = (ValueObject)obj;
        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public static bool operator ==(ValueObject one, ValueObject two) => EqualOperator(one, two);

    public static bool operator !=(ValueObject one, ValueObject two) => NotEqualOperator(one, two);

    protected static bool NotEqualOperator(ValueObject left, ValueObject right) => !EqualOperator(left, right);

    public override int GetHashCode() => GetEqualityComponents()
                                            .Select(x => (x?.GetHashCode()) ?? 0)
                                            .Aggregate((x, y) => x ^ y);

    protected abstract IEnumerable<object> GetEqualityComponents();
}
