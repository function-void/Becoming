using Becoming.Core.Common.Abstractions.Contracts;
using Becoming.Core.Common.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Becoming.Core.Common.Infrastructure.Repositories;

public abstract class BaseRepository<Model> : IBaseRepository<Model> where Model : BaseModel, new()
{
    protected DbContext _context;
    protected DbSet<Model> _dbSet;

    protected BaseRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<Model>();
    }

    public virtual async Task<int> DeleteAsync(Guid id, CancellationToken token = default)
    {
        _dbSet.Remove(new Model { Id = id });
        return await _context.SaveChangesAsync(token);
    }

    public virtual async Task<int> CreateAsync(Model newDataModel, CancellationToken token = default)
    {
        await _dbSet.AddAsync(newDataModel);
        return await _context.SaveChangesAsync(token);
    }

    public virtual async Task<int> SimpleUpdate(Model changedDataModel, CancellationToken token = default)
    {
        _dbSet.Update(changedDataModel);
        return await _context.SaveChangesAsync(token);
    }

    public abstract Task<int> UseOriginalUpdate(Model changedModel, Model? orinalModel = null);

    public virtual async Task RequiredRelationUpdate(Model model, Guid targetId, IDbContextTransaction? transaction = default, CancellationToken token = default)
    {
        using var newTransaction = transaction ?? await _context.Database.BeginTransactionAsync(token);

        throw new NotImplementedException();
    }

    public virtual async Task RequiredRelationUpdate(Model model, Guid targetId, Guid[] spares, IDbContextTransaction? transaction = default, CancellationToken token = default)
    {
        using var newTransaction = transaction ?? await _context.Database.BeginTransactionAsync(token);

        throw new NotImplementedException();
    }

    public virtual async Task<Model?> GetAsync(Guid id) => await _dbSet.FindAsync(id);

    public IQueryable<Model> GetAllAsIQueryable() => _dbSet.AsQueryable();
}
