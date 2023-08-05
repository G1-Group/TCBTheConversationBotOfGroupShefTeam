namespace TCB.Aplication.Infrastructure.Service.Interface;

public interface IDataSarvice<T>
{
    public Task<T> CreateData(T data);
    public Task<T> UpdateData(long Id,T data);
    public Task<List<T>> GetAllData();
    public Task<T> FindByIdData(long Id);
    public Task<T> DeleteData(long Id);
}