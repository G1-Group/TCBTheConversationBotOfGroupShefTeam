using TCB.Aplication.Domain;

namespace TCB.Aplication.Services.Interface;

public interface  IService<T>  where T : ModelBase
{
    
    /// <summary>
    /// Delete Data from Sql
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public Task<T> Delete(T data);
    
    /// <summary>
    /// Update data from Sql
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public Task<T> Update(long Id,T data);
    
    
    /// <summary>
    /// Get All Data from Sql
    /// </summary>
    /// <returns></returns>
    public Task<List<T>> GetAllModel();
    
    
    /// <summary>
    /// Find Data from Sql where Id equals
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public Task<T> FindById(long Id);
    
 
}