using TCB.Aplication.Domain;

namespace TCB.Aplication.Services.Interface;

public interface IAnonymChatService : IService<AnonymChat>
{
    /// <summary>
    /// Find Data from Sql where NickName equals
    /// </summary>
    /// <param name="nickName"></param>
    /// <returns></returns>
    public Task<AnonymChat> FindByNickNameModel(string nickName);
}