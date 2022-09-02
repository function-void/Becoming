namespace Becoming.Core.Common.Abstractions.Contracts;

public interface IBaseRepository
{
    //Remove(new Entity { Id = id }) ;
    public void Delete(Guid Id);
}