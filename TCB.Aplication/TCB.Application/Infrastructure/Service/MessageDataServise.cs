using Npgsql;
using TCB.Aplication.DataProviderFolder;
using TCB.Aplication.Domain;
using TCB.Aplication.Domain.Querys;
using TCB.Aplication.Infrastructure.Service.Interface;

namespace TCB.Aplication.Infrastructure.Service;

public class MessageDataServise : DataProvider,IMessageDataService
{

    public MessageDataServise(string cannectionString) : base(cannectionString)
    {
        
    }

    public async Task<Message> CreateData(Message data)
    {
        var result = await this.ExecuteNonResult(QueryMessage.InsertQuery(), new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", data.Id),
            new NpgsqlParameter("@p1", data.FromId),
            new NpgsqlParameter("@p2",data.BoardId),
            new NpgsqlParameter("@p3",data.AnonymChatId),
            new NpgsqlParameter("@p4",data.text),
            new NpgsqlParameter("@p5",data.time),
            new NpgsqlParameter("@p6",data.status),
            new NpgsqlParameter("@p7", data.messageStatus)

        }); 
        
        return await FindByIdData(data.Id);
    }

    public async Task<Message> UpdateData(long Id, Message message)
    {
        var result = await this.ExecuteNonResult(QueryMessage.UpdateQuery(), new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", Id),
            new NpgsqlParameter("@p1", message.FromId),
            new NpgsqlParameter("@p2", message.BoardId),
            new NpgsqlParameter("@p3", message.AnonymChatId),
            new NpgsqlParameter("@p4", message.text),
            new NpgsqlParameter("@p5", message.time),
            new NpgsqlParameter("@p6", message.status),
            new NpgsqlParameter("@p7", message.messageStatus)
        }); 
        
        return await FindByIdData(Id);
    }
    public async Task<Message> InsertMessage(Message message)
    {
         await this.ExecuteNonResult(QueryMessage.InsertQuery(), new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", message.Id),
            new NpgsqlParameter("@p1", message.FromId),
            new NpgsqlParameter("@p2", message.BoardId),
            new NpgsqlParameter("@p3", message.AnonymChatId),
            new NpgsqlParameter("@p4", message.text),
            new NpgsqlParameter("@p5", message.time),
            new NpgsqlParameter("@p6", message.status),
            new NpgsqlParameter("@p7", message.messageStatus)
        });
         return await FindByIdData(message.Id);
    }
    

    public async Task<List<Message>> GetAllData()
    {
        var reader = await this.ExecuteWithResult(QueryBoard.SelectQuery(), null);
        List<Message> resultMessages = new List<Message>();
        while (reader.Read())
            resultMessages.Add(ReaderDataModel(reader));
        return resultMessages;
    }

    public async Task<Message> FindByIdData(long id)
    {
        var reader = await this.ExecuteWithResult(QueryMessage.SelectByIdQuery(),new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", id)
        });
        List<Message> resulstMessages = new List<Message>();
        while (reader.Read())
        {
            resulstMessages.Add(this.ReaderDataModel(reader));
        }
        
        return resulstMessages.FirstOrDefault();
    }

    public async Task<Message> DeleteData(long id)
    {
        Message message = await FindByIdData(id);
        var resultMessage = await ExecuteNonResult(QueryMessage.DeleteQuery(), new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", id)
        });
        return message;
    }

    public async Task<List<Message>> FintByFromId(long fromId)
    {
        var reader = await this.ExecuteWithResult(QueryMessage.SelectByFromId(), new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", fromId)
        });
        List<Message> messages = new List<Message>();
        while (reader.Read())
        {
            messages.Add(this.ReaderDataModel(reader));
        }

        return messages;
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
            AnonymChatId = reader.GetInt64(3),
            text = reader.GetString(4),
            time = reader.GetDateTime(5),
            status = (MessageType)reader.GetInt32(6),
            messageStatus = (MessageStatus)reader.GetInt32(7)
        };
    }
    
}