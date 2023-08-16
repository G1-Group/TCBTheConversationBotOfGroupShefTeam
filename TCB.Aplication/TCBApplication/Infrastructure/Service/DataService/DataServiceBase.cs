using Microsoft.EntityFrameworkCore;
using TCB.Aplication.Domain;
using TCB.Aplication.Infrastructure.Service.Interface;

namespace TCB.Aplication.Infrastructure.Service.DataService;

public abstract class DataServiceBase<T>: IDataServiceBase<T> where T : ModelBase
{
    private readonly DbContext _context;

    public DataServiceBase(DbContext context)
    {
        _context = context;
    }
    
    
    public IQueryable<T> GetAll()
    {
        return this._context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(long id)
    {
        return await this.GetAll().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<T> AddAsync(T data)
    {
        var entityEntry = await this._context.AddAsync(data);
        await this._context.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task<T> UpdateAsync(T data)
    {
        var entityEntry =  this._context.Update(data);
        await this._context.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task<T> RemoveAsync(T data)
    {
        var entityEntry = this._context.Remove(data);
        await this._context.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task<T> RemoveAsync(long id)
    {
        var entity = await GetByIdAsync(id);
        if (entity is T data)
            return await this.RemoveAsync(data);
        throw new Exception("Entry not found");
    }
}