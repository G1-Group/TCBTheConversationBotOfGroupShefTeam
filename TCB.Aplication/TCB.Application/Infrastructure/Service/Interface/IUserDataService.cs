using Npgsql;
using TCB.Aplication.Domain;

namespace TCB.Aplication.Infrastructure.Service.Interface;

public interface IUserDataService : IDataSarvice<User>
{
    public Task<User> FindByPassword(string password);

    public Task<User> FindByPhoneNumber(string phoneNumber);
    
    public Task<User> FindByUserId(long userId);

    public User ReaderDataModel(NpgsqlDataReader reader);
}