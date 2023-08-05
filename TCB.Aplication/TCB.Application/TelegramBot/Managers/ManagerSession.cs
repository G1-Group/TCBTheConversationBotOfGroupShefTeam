using TCB.Aplication.Domain;
using TCB.Aplication.Infrastructure.Service;
using TCB.Aplication.TelegramBot.Managers.Interface;

namespace TCB.Aplication.TelegramBot.Managers;

public class ManagerSession:ISessionManager
{
    private readonly UserDataService _userDataService;
    public List<Session> Sessions { get; set; } = new List<Session>();

    public ManagerSession(UserDataService userDataService)
    {
        _userDataService = userDataService;
    }

    public async Task<Session> GetSessionByChatId(long chatId)
    {
        User user = await _userDataService.FindByUserId(chatId);
        if (user is not null)
            throw new Exception(" Not Found");

        
        var Session1 = Sessions.FindLast(x => x.User.Id== user.Id);
        if (Session1 is null)
        {
            var session = new Session()
            {
                User = user,
                Id = user.TelegramClientId,
            };
            Sessions.Add(session);
            return session;
        }

        return Session1;
    }


}