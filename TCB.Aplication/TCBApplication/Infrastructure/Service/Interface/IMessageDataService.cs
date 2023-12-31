using TCB.Aplication.Domain;

namespace TCB.Aplication.Infrastructure.Service.Interface;

public interface IMessageDataService:IDataSarvice<Message>
{
    public Task<List<Message>> FintByFromId(long FromId);
    public Task<List<Message>> GetAllFindBoardId(long BoardId);
}