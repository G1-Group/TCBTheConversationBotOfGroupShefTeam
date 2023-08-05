using TCB.Aplication.DataProviderFolder;
using TCB.Aplication.Domain;
using TCB.Aplication.Infrastructure.Service.Interface;

namespace TCB.Aplication.Infrastructure.Service;

public class MessageTCBDataService:DataProvider,IMessageTCBDataService
{
    public MessageTCBDataService(string cannectionString) : base(cannectionString)
    {
    }

    public async Task<MessageTCB> CreateData(MessageTCB data)
    {
        throw new NotImplementedException();
    }

    public async Task<MessageTCB> UpdateData(long Id, MessageTCB data)
    {
        throw new NotImplementedException();
    }

    public async Task<List<MessageTCB>> GetAllData()
    {
        throw new NotImplementedException();
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
}