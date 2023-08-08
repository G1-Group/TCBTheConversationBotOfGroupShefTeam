using TCB.Aplication.Domain;
using TCB.Aplication.Infrastructure.Service;
using TCB.Aplication.Services.Interface;

namespace TCB.Aplication.Services;

public class AnonymChatService : IAnonymChatService
{
    private AnonymChatDataService _anonymChatDataService;
    
    public AnonymChatService(AnonymChatDataService anonymChatDataService)
    {
        _anonymChatDataService = anonymChatDataService;
    }
    
    public async Task<AnonymChat> Add(AnonymChat data)
    {
        AnonymChat anonymChat = await _anonymChatDataService.FindByIdData(data.Id);
        if (anonymChat is not null)
            return anonymChat;
        return await _anonymChatDataService.CreateData(data);
    }

    public async Task<AnonymChat> Delete(AnonymChat data)
    {
        AnonymChat anonymChat =await _anonymChatDataService.FindByIdData(data.Id);
        if (anonymChat is null)
            return null;

        else
        {
            _anonymChatDataService.DeleteData(data.Id);
            return anonymChat;
        }
    }

    public async Task<AnonymChat> Update(long Id, AnonymChat data)
    {
        return await _anonymChatDataService.UpdateData(Id, data);
    }

    public async Task<List<AnonymChat>> GetAllModel()
    {
        return await _anonymChatDataService.GetAllData();
    }

    public async Task<AnonymChat> FindById(long Id)
    {
        throw new NotImplementedException();
    }

    public async Task<AnonymChat> FindByIdModel(long Id)
    {
        return await _anonymChatDataService.FindByIdData(Id);
    }

    public Task<AnonymChat> FindByNickNameModel(string nickName)
    {
        //todo add function find client us nickname in future;
        return null;
    }
}