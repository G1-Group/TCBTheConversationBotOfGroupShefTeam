using TCB.Aplication.Domain;

namespace TCB.Aplication.Services.Interface;

public interface IAnonymChatService : IService<AnonymChat>
{
    
    public  Task<AnonymChat> Add(AnonymChat data);
    public  Task<AnonymChat> Delete(AnonymChat data);
    public  Task<AnonymChat> Update(long Id, AnonymChat data);
    public  Task<List<AnonymChat>> GetAllModel();
    public  Task<AnonymChat> FindById(long Id);
    public  Task<AnonymChat> FindByIdModel(long Id);
    public Task<AnonymChat> FindByNickNameModel(string nickName);
}