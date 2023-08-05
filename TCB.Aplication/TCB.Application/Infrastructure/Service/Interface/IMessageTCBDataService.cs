using TCB.Aplication.Domain;

namespace TCB.Aplication.Infrastructure.Service.Interface;

public interface IMessageTCBDataService:IDataSarvice<MessageTCB>
{
    public Task<MessageTCB> FintByFromId(long FromId);
    public Task<List<MessageTCB>> GetAllFindBoardId(long BoardId);
}