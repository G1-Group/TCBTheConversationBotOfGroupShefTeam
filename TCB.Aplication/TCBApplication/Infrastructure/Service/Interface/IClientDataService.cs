using Npgsql;
using TCB.Aplication.Domain;

namespace TCB.Aplication.Infrastructure.Service.Interface;

public interface IClientDataService : IDataSarvice<Client>
{
    public Task<Client> FindByUserId(long id);
    public Task<Client> FindByNickName(string nickName);
    public Client ReaderDataModel(NpgsqlDataReader reader);
}