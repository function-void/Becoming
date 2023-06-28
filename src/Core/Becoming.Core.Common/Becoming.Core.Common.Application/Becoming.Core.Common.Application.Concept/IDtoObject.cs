namespace Becoming.Core.Common.Application.Concept;

public interface IDtoObject<out T>
{
    T ToDomainModel();
}
