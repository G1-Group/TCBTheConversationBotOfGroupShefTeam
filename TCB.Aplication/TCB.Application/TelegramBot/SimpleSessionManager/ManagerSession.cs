using TCB.Aplication.Domain;
using TCB.Aplication.Infrastructure.Service;
using TCB.Aplication.TelegramBot.Managers.Interface;

namespace TCB.Aplication.TelegramBot.Managers;

public class ManagerSession:ISessionManager
{
    private readonly UserDataService _userDataService;
    public List<Session> Sessions { get; set; } 

    public ManagerSession(UserDataService userDataService)
    {
        _userDataService = userDataService;
        Sessions = new List<Session>();
    }

    public async Task<Session> GetSessionByChatId(long chatId)
    {
        User user = await _userDataService.FindByChatId(chatId);
        var session = Sessions.Find(x => x.TelegramChatId== chatId);
        if (session is null)
        {
            session = new Session()
            {
                Id = 1,
                TelegramChatId = chatId
            };
            Sessions.Add(session);
            return session;
        }

        return session;
    }


}