using Becoming.Core.Common.Domain.Seedwork;

namespace Becoming.Core.Common.Application.Concept;

public interface IDataTransferObject<out TResult> where TResult : Entity
{
    TResult ToDomainModel();
}
