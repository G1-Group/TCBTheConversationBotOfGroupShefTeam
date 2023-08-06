using System.Data;
using Npgsql;
using TCB.Aplication.DataProviderFolder;
using TCB.Aplication.Domain;
using TCB.Aplication.Domain.Querys;
using TCB.Aplication.Infrastructure.Service.Interface;
using TCB.Aplication.Domain;

namespace TCB.Aplication.Infrastructure.Service;

public class MessageDataService : DataProvider,IMessageDataService
{
    public MessageDataService(string cannectionString) : base(cannectionString)
    {
        
    }

    public async Task<Message> CreateData(Message data)
    {
        var result = await this.ExecuteNonResult(QueryMessage.InsertQuery(), new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", data.Id),
            new NpgsqlParameter("@p1", data.FromId),
            new NpgsqlParameter("@p2",data.BoardId),
            new NpgsqlParameter("@p3",data.chatId),
            new NpgsqlParameter("@p4",data.message),
            new NpgsqlParameter("@p5",data.time),
            new NpgsqlParameter("@p6",data.status)

        });
        return await FindByIdData(data.Id);
    }

    public async Task<Message> UpdateData(long Id, Message message)
    {
        var result = await this.ExecuteNonResult(QueryMessage.UpdateQuery(), new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", message.Id),
            new NpgsqlParameter("@p1", message.FromId),
            new NpgsqlParameter("@p2", message.BoardId),
            new NpgsqlParameter("@p3", message.chatId),
            new NpgsqlParameter("@p4", message.message),
            new NpgsqlParameter("@p5", message.time),
            new NpgsqlParameter("@p6", message.status)
        });
        return await FindByIdData(message.Id);
    }

    public async Task<int> InsertMessage(Message message)
    {
        return await this.ExecuteNonResult(QueryMessage.InsertQuery(), new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", message.Id),
            new NpgsqlParameter("@p1", message.FromId),
            new NpgsqlParameter("@p2", message.BoardId),
            new NpgsqlParameter("@p3", message.chatId),
            new NpgsqlParameter("@p4", message.message),
            new NpgsqlParameter("@p5", message.time),
            new NpgsqlParameter("@p6", message.status)
        });
    }


    public async Task<List<Message>> GetAllData()
    {
        var reader = await this.ExecuteWithResult(QueryBoard.SelectQuery(), null);
        List<Message> resultMessages = new List<Message>();
        while (reader.Read())
            resultMessages.Add(ReaderDataModel(reader));
        return resultMessages;
    }
    
    public async Task<Message> DeleteData(long id)
    {
        Message message = await FintByFromId(id);
        var resultMessage = await ExecuteNonResult(QueryMessage.DeleteQuery(), new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", id)
        });
        return message;
    }

    public async Task<Message> FindByIdData(long id)
    {
        var reader = await this.ExecuteWithResult(QueryMessage.SelectByIdQuery(),new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", id)
        });
        List<Message> resulstMessages = new List<Message>();
        while (reader.Read())
            resulstMessages.Add(this.ReaderDataModel(reader));

        return resulstMessages.FirstOrDefault();
    }

    public async Task<Message> FintByFromId(long fromId)
    {
        var reader = await this.ExecuteWithResult(QueryMessage.SelectByFromId(), new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", fromId)
        });
        List<Message> messages = new List<Message>();
        while (reader.Read())
            messages.Add(ReaderDataModel(reader));
        return messages.FirstOrDefault();
    }
    
    public async Task<List<Message>> GetAllFindBoardId(long boardId)
    {
        var reader = await this.ExecuteWithResult(QueryMessage.SelectByBoardId(), new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", boardId)
        });
        List<Message> resultMessages = new List<Message>();
        while (reader.Read())
        {
            resultMessages.Add(this.ReaderDataModel(reader));
        }

        return resultMessages;
    }
    
    
    private Message ReaderDataModel(NpgsqlDataReader reader)
    {
        
        return new Message()
        {

            Id = reader.GetInt64(0),
            FromId = reader.GetInt64(1),
            BoardId = reader.GetInt64(2),
            chatId = reader.GetInt64(3),
            message = reader.GetString(4),
            time = reader.GetDateTime(5),
            status = (MessageType)reader.GetInt32(6),
        };
    }
    
}



