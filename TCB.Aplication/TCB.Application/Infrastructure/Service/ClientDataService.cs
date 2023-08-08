using System.Data;
using Npgsql;
using TCB.Aplication.DataProviderFolder;
using TCB.Aplication.Domain;
using TCB.Aplication.Domain.Querys;
using TCB.Aplication.Infrastructure.Service.Interface;

namespace TCB.Aplication.Infrastructure.Service;

public class ClientDataService : DataProvider
{

    public ClientDataService(string cannectionString) 
        : base(cannectionString)
    {
    }
    /// <summary>
    /// Create      
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public async Task<Client> CreateData(Client data)
    {
        var result = await this.ExecuteNonResult(QueryClient.InsertQuery, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", data.Id),
            new NpgsqlParameter("@p1", data.UserId),
            new NpgsqlParameter("@p2", data.TelegramChatId),
            new NpgsqlParameter("@p3", data.NickName),
            new NpgsqlParameter("@p4", data.Status),
            new NpgsqlParameter("@p5", data.IsPremium),
            new NpgsqlParameter("@p6", data.ClientInAnonymChat)
        });
        
        return await FindByIdData(data.Id);
    }

    
    
    
    public async Task<Client> UpdateData(long Id, Client data)
    {
        var result = await this.ExecuteNonResult(QueryClient.InsertQuery, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", Id),
            new NpgsqlParameter("@p1", data.UserId),
            new NpgsqlParameter("@p2", data.TelegramChatId),
            new NpgsqlParameter("@p3", data.NickName),
            new NpgsqlParameter("@p4", data.Status),
            new NpgsqlParameter("@p5", data.IsPremium),
            new NpgsqlParameter("@p6", data.ClientInAnonymChat)
        });
        
        return await FindByIdData(data.Id);
    }

    
    
    public async Task<List<Client>> GetAllData()
    {
        var result = await ExecuteWithResult(QueryClient.SelectQuery, null);
        List<Client> clients = new List<Client>();
        while (result.Read())
        {
            clients.Add(ReaderDataModel(result));
        }

        return clients;
    }

    public async Task<Client> FindByIdData(long Id)
    {
        var result = await this.ExecuteWithResult(QueryClient.InsertQuery, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", Id)
        });
        List<Client> clients = new List<Client>();

        while (result.Read())
            clients.Add(ReaderDataModel(result));
        return clients.FirstOrDefault();
        
        
    }

    public async Task<Client> DeleteData(long Id)
    {
        Client client = await FindByIdData(Id);
        var result = await ExecuteWithResult(QueryClient.DeleteQuery, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", Id)
        });
        return client;
    }

    public async Task<Client> FindByUserId(long id)
    {
        
        var result = await ExecuteWithResult(QueryClient.SelectByUserIdQuery, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p1", id)
        });
        List<Client> clients = new List<Client>();
        while (result.Read())
        {
            clients.Add(ReaderDataModel(result));
        }

        return clients.FirstOrDefault();
    }

    public async Task<Client> FindByNickName(string nickName)
    {
        var result = await ExecuteWithResult(QueryClient.SelectByNickNameQuery, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p3", nickName)
        });
        List<Client> clients = new List<Client>();

        while (result.Read())
        {
            clients.Add(ReaderDataModel(result));
        }

        return clients.FirstOrDefault();

    }
    
    
    
    
    /// <summary>
    /// Convert to client 
    /// </summary>
    /// <param name="reader"></param>
    /// <returns></returns>
    public Client ReaderDataModel(NpgsqlDataReader reader)
    {
        return new Client()
        {
            Id = reader.GetInt64(0),
            UserId = reader.GetInt64(1),
            TelegramChatId = reader.GetInt64(2),
            NickName = reader.GetString(3),
            //Status = reader.GetChars(4),
            IsPremium = reader.GetBoolean(5),
            ClientInAnonymChat = reader.GetBoolean(6)
            
        };
    }
}