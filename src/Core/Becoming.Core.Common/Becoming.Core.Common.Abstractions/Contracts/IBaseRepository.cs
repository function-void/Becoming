using Microsoft.EntityFrameworkCore.Storage;

namespace Becoming.Core.Common.Abstractions.Contracts;

public interface IBaseRepository<Model> where Model : class, new()
{
    Task<int> DeleteAsync(Guid id, CancellationToken token = default);
    Task<int> CreateAsync(Model model, CancellationToken token = default);
    Task<int> SimpleUpdate(Model changedDataModel, CancellationToken token = default);
    Task<int> UseOriginalUpdate(Model changedModel, Model? orinalModel = null);
    Task RequiredRelationUpdate(Model model, Guid targetId, IDbContextTransaction? transaction = default, CancellationToken token = default);
    Task RequiredRelationUpdate(Model model, Guid targetId, Guid[] spares, IDbContextTransaction transaction, CancellationToken token = default);
    Task<Model?> GetAsync(Guid id);
    IQueryable<Model> GetAllAsIQueryable();
}