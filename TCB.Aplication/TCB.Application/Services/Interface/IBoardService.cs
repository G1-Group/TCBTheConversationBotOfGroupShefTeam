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
}