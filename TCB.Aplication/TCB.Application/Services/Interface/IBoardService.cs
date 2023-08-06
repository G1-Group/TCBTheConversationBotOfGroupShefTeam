using TCB.Aplication.Domain;

namespace TCB.Aplication.Services.Interface;

public interface IBoardService:IService<Board>
{
    /// <summary>
    /// Find Data from Sql where NickName equals
    /// </summary>
    /// <param name="nickName"></param>
    /// <returns></returns>
    public Task<Board> FindByNickNameModel(string nickName);



    /// <summary>
    /// Write to Message
    /// </summary>
    /// <param name="BoardId"></param>
    /// <param name="messageTcb"></param>
    /// <returns></returns>
    public Task WriteMessageToBoard(long BoardId, Message messageTcb);


    public Task<List<Message>> ReadMessageToBoard(long Id);
}