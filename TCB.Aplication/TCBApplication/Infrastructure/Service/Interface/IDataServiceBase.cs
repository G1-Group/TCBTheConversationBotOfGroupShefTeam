using TCB.Aplication.Domain;

namespace TCB.Aplication.Infrastructure.Service.Interface;

public interface IDataServiceBase<T> where T: ModelBase
{
       IQueryable<T> GetAll();
       Task<T?> GetByIdAsync(long id);
       Task<T?> AddAsync(T data);

       Task<T> UpdateAsync(T data);
       Task<T> RemoveAsync(T data);
       Task<T> RemoveAsync(long id);
} 