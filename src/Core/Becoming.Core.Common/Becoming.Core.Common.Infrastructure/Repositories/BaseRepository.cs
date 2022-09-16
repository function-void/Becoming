﻿using Becoming.Core.Common.Infrastructure.Shared;
using Becoming.Core.Common.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Becoming.Core.Common.Seedwork.Interfaces;

namespace Becoming.Core.Common.Infrastructure.Repositories;

public abstract class BaseRepository<Context, Model> : IBaseRepository<Model>
    where Context : BaseContext
    where Model : BaseModel, new()
{
    protected Context _context;
    protected DbSet<Model> _dbSet;

    protected BaseRepository(Context context)
    {
        _context = context;
        _dbSet = context.Set<Model>();
    }

    public virtual async Task<int> DeleteAsync(Guid id, CancellationToken token = default)
    {
        _dbSet.Remove(new Model { Id = id });
        return await _context.SaveChangesAsync(token);
    }

    public void Delete(Model model) => _dbSet.Remove(model);

    public virtual async Task<int> CreateAsync(Model newDataModel, CancellationToken token = default)
    {
        await CreateAsync(newDataModel);
        return await _context.SaveChangesAsync(token);
    }

    public async Task CreateAsync(Model newDataModel) => await _dbSet.AddAsync(newDataModel);

    public virtual async Task<int> SimpleUpdateAsync(Model changedDataModel, CancellationToken token = default)
    {
        SimpleUpdate(changedDataModel);
        return await _context.SaveChangesAsync(token);
    }

    public void SimpleUpdate(Model changedDataModel) => _dbSet.Update(changedDataModel);

    public abstract Task<int> UseOriginalUpdateAsync(Model changedDataModel, Model? orinalModel = null, CancellationToken token = default);

    public virtual async Task<Model?> GetAsync(Guid id) => await _dbSet.FindAsync(id);

    public IQueryable<Model> GetAllAsIQueryable() => _dbSet.AsQueryable();
}
