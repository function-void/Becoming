namespace Becoming.Core.Common.Infrastructure.DataAccess.Model;

public abstract class BaseModel<T>
{
    public T Id { get; set; } = default!;
}

public abstract class BaseModel : BaseModel<Guid> { }