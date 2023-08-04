using System.Runtime.Serialization.Json;
using Npgsql;
using TCB.Aplication.DataProviderFolder;
using TCB.Aplication.Domain;
using TCB.Aplication.Domain.Querys;
using TCB.Aplication.Infrastructure.Service.Interface;

namespace TCB.Aplication.Infrastructure.Service;

public class UserDataService : DataProvider 
{
    public UserDataService(string cannectionString) 
        : base(cannectionString)
    {
    }
    
    
    public async Task<User> CreateData(User data)
    {
        var result = await ExecuteNonResult(QueryUser.InsertQuery, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", data.Id),
            new NpgsqlParameter("@p1", data.TelegramClientId),
            new NpgsqlParameter("@p2", data.PhoneNumber),
            new NpgsqlParameter("@p3", data.Password)
        });

        return await FindByIdData(data.Id);
    }

    
    
    public async Task<User> UpdateData(long Id, User data)
    {
       
        var result = await ExecuteNonResult(QueryUser.InsertQuery, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", data.Id),
            new NpgsqlParameter("@p1", data.TelegramClientId),
            new NpgsqlParameter("@p2", data.PhoneNumber),
            new NpgsqlParameter("@p3", data.Password)
        });

        return await FindByIdData(data.Id);
    }

    public async Task<List<User>> GetAllData()
    {
        var result = await ExecuteWithResult(QueryUser.SelectQuery, null);

        List<User> users = new List<User>();

        while (result.Read())
        {
            users.Add(ReaderDataModel(result));
        }

        return users;
    }

    
    
    public async Task<User> FindByIdData(long Id)
    {
        var result = await ExecuteWithResult(QueryUser.SelectByIdQuery, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", Id)
        });
        List<User> users = new List<User>();
        while (result.Read())
        {
            users.Add(ReaderDataModel(result));
        }

        return users.FirstOrDefault();
    }

    
    
    
    public async Task<User> DeleteData(long Id)
    {
        User user = await FindByUserId(Id);

        var result = await ExecuteWithResult(QueryUser.DeleteQuery, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", Id),
        });
        return user;
    }

    public async Task<User> FindByPassword(string password)
    {

        var result = await ExecuteWithResult(QueryUser.SelectByPasswordQuery, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p3", password),
        });

        List<User> users = new List<User>();
        while (result.Read())
        {
            users.Add(ReaderDataModel(result));
        }

        return users.FirstOrDefault();
    }

    public async Task<User> FindByPhoneNumber(string phoneNumber)
    {
        var result = await ExecuteWithResult(QueryUser.SelectByPhoneNumberQuery, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p2", phoneNumber),
        });

        List<User> users = new List<User>();
        while (result.Read())
        {
            users.Add(ReaderDataModel(result));
        }

        return users.FirstOrDefault();
    }

    public async Task<User> FindByUserId(long userId)
    {
        var result = await ExecuteWithResult(QueryUser.SelectByUserIdQuery, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p1", userId),
        });
        List<User> users = new List<User>();

        while (result.Read())
        {
            users.Add(ReaderDataModel(result));
        }

        return users.FirstOrDefault();
    }

    public User ReaderDataModel(NpgsqlDataReader reader)
    {
        return new User()
        {
            Id = reader.GetInt16(0),
            TelegramClientId = reader.GetInt16(1),
            PhoneNumber = reader.GetString(2),
            Password = reader.GetString(3)
        };
    }
}