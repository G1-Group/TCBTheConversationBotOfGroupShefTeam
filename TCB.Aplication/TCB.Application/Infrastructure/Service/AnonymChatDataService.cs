using Npgsql;
using TCB.Aplication.DataProviderFolder;
using TCB.Aplication.Domain;
using TCB.Aplication.Domain.Querys;
using TCB.Aplication.Infrastructure.Service.Interface;

namespace TCB.Aplication.Infrastructure.Service;

public class AnonymChatDataService:DataProvider
{
    public AnonymChatDataService(string cannectionString) : base(cannectionString)
    {
    }
    
    
    public async Task<AnonymChat> CreateData(AnonymChat data)
    {
        var result = await this.ExecuteNonResult(QueryAnonymChat.InsertQuery, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", data.Id),
            new NpgsqlParameter("@p1", data.ClientFromId),
            new NpgsqlParameter("@p2", data.ConnectClientId),
            new NpgsqlParameter("@p3", data.Status),
            new NpgsqlParameter("@p4", data.CreateData),

        });


        return await FindByIdData(data.Id);
    }

    public async Task<AnonymChat> UpdateData(long Id, AnonymChat data)
    {
        var result = await ExecuteNonResult(QueryAnonymChat.UpdateQuery, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", Id),
            new NpgsqlParameter("@p1", data.ClientFromId),
            new NpgsqlParameter("@p2", data.ConnectClientId),
            new NpgsqlParameter("@p3", data.Status),
            new NpgsqlParameter("@p4", data.CreateData),
        });
        return await FindByIdData(Id);
    }

    public async Task<List<AnonymChat>> GetAllData()
    {
        var reader = await ExecuteWithResult(QueryAnonymChat.SelectQuery, null);
        List<AnonymChat> chats = new List<AnonymChat>();
        while (reader.Read())
            chats.Add(ReaderDataModel(reader));
        return chats;
    }

    public async Task<AnonymChat> FindByIdData(long Id)
    {
        var reader = await ExecuteWithResult(QueryAnonymChat.SelectByIdQuery, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0",Id)
        });
        System.Collections.Generic.IList<AnonymChat> chats = new List<AnonymChat>();
        while (reader.Read())
            chats.Add(ReaderDataModel(reader));
        return chats.FirstOrDefault();
    }

    public async Task<AnonymChat> DeleteData(long Id)
    {
        AnonymChat chat = await FindByIdData(Id);
        var result = await ExecuteNonResult(QueryAnonymChat.DeleteQuery, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", chat.Id)
        });
        return chat;
    }

    public async Task<AnonymChat> FindByFromIdOrClientId(long Id)
    {
        var reader = await ExecuteWithResult(QueryAnonymChat.SelectByIdQuery, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p1",Id)
        });
        List<AnonymChat> chats = new List<AnonymChat>();
        while (reader.Read())
            chats.Add(ReaderDataModel(reader));
        return chats.FirstOrDefault();
    }

    public async Task<AnonymChat> FindByStatus(int role)
    {
        var reader = await ExecuteWithResult(QueryAnonymChat.SelectByIdQuery, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p3",role)
        });
        List<AnonymChat> chats = new List<AnonymChat>();
        while (reader.Read())
            chats.Add(ReaderDataModel(reader));
        return chats.FirstOrDefault();
    }



    private AnonymChat ReaderDataModel(NpgsqlDataReader reader)
    {
        return new AnonymChat()
        {
            Id = reader.GetInt64(0),
            ClientFromId = reader.GetInt64(1),
            ConnectClientId = reader.GetInt64(2),
            //Status = reader.GetInt32(3),
            CreateData = reader.GetDateTime(4)
        };
    }
    
}