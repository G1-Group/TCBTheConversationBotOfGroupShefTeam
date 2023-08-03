using TCB.Aplication.Domain;

namespace TCB.Aplication.Services.Interface;

public interface  IService<T>  where T : ModelBase
{
    public void Add(T data);
    public void Delete(T data);
    public List<T> GetAllModel();
    public T FindModel(long id);
    public void AddRange(List<T> data);
    
 
}