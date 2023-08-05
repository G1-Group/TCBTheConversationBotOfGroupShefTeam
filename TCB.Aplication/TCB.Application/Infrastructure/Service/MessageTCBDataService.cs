using System.Data;
using Npgsql;
using TCB.Aplication.DataProviderFolder;
using TCB.Aplication.Domain;
using TCB.Aplication.Domain.Querys;
using TCB.Aplication.Infrastructure.Service.Interface;

namespace TCB.Aplication.Infrastructure.Service;

public class MessageTCBDataService:DataProvider,IMessageTCBDataService
{
    public MessageTCBDataService(string cannectionString) : base(cannectionString)
    {
    }

    public async Task<MessageTCB> CreateData(MessageTCB data)
    {
        var result = await this.ExecuteNonResult(MessageTCBQuery.InsertQuery(), new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", data.Id),
            new NpgsqlParameter("@p1", data.FromId),
            new NpgsqlParameter("@p2",data.BoardId),
            new NpgsqlParameter("@p3",data.chatId),
            new NpgsqlParameter("@p4",data.text),
            new NpgsqlParameter("@p5",data.time),
            new NpgsqlParameter("@p6",data.status),
            new NpgsqlParameter("@p7",data.messageStatus)

        });
        return await FindByIdData(data.Id);
    }

    public async Task<MessageTCB> UpdateData(long Id, MessageTCB data)
    {
        var result = await this.ExecuteNonResult(MessageTCBQuery.UpdateQuery(), new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", data.Id),
            new NpgsqlParameter("@p1", data.FromId),
            new NpgsqlParameter("@p2", data.BoardId),
            new NpgsqlParameter("@p3", data.chatId),
            new NpgsqlParameter("@p4", data.text),
            new NpgsqlParameter("@p5", data.time),
            new NpgsqlParameter("@p6", data.status),
            new NpgsqlParameter("@p7", data.messageStatus)
        });
        return await FindByIdData(data.Id);
    }

    public async Task<List<MessageTCB>> GetAllData()
    {
        var reader = await this.ExecuteWithResult(QueryBoard.SelectQuery(), null);
        List<MessageTCB> messages = new List<MessageTCB>();
        while (reader.Read())
            messages.Add(ReaderDataModel(reader));
        return messages;
    }

    public async Task<MessageTCB> FindByIdData(long Id)
    {
        throw new NotImplementedException();
    }

    public async Task<MessageTCB> DeleteData(long Id)
    {
        throw new NotImplementedException();
    }

    public async Task<MessageTCB> FintByFromId(long FromId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<MessageTCB>> GetAllFindBoardId(long BoardId)
    {
        throw new NotImplementedException();
    }
    
    
    private MessageTCB ReaderDataModel(NpgsqlDataReader reader)
    {
        return new MessageTCB()
        {
            //( id ,from_id , board_id , chat_id,text, time , status ,message_status) 

            Id = reader.GetInt64(0),
            FromId = reader.GetInt64(1),
            BoardId = reader.GetInt64(2),
            chatId = reader.GetInt64(3),
            text = reader.GetString(4),
            time = reader.GetDateTime(5),
            //status = (me)reader.GetInt32(6),
            //messageStatus = reader.GetInt32(7)
        };
    }
    
    
}