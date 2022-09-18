using Becoming.Core.Common.Seedwork.Models;

namespace Becoming.Core.Common.Abstractions.Interfaces;

public interface IDtoObject<T>
    where T : Entity
{
    T ToDomainModel();
}
