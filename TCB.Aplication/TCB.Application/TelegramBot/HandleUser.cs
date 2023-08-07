using TCB.Aplication.Infrastructure.Service;
using TCB.Aplication.TelegramBot.Managers;
using Telegram.Bot.Types;
using User = TCB.Aplication.Domain.User;

namespace TCB.Aplication.TelegramBot;

public class HandleUser
{
    private readonly HomeController _homeController;
    private readonly UserDataService _userDataService;
    public List<Session> Sessions { get; set; }
    public List<ControllerContext> Contexts { get; set; }

    public HandleUser(HomeController homeController,UserDataService userDataService)
    {
        _homeController = homeController;
        _userDataService = userDataService;
        Sessions = new List<Session>();
    }

    public async Task Handle(Update update)
    {
        ControllerContext context = Contexts.Find(x => x.Session.User.TelegramClientId == update.Message.Chat.Id);
        if (context is not null)
        {
            context.Update = update;
            _homeController.HandleAction(context);
            return;
        }
        
        User user = await _userDataService.FindByChatId(update.Message.Chat.Id);
        if (user is null)
        {
            user = new User()
            {
                TelegramClientId = update.Message.Chat.Id
            };
        }

        Session session =await FindSession(user);
        context = new ControllerContext()
        {
            Update = update,
            Session = session
        };
        Contexts.Add(context);
         _homeController.HandleAction(context);
    }



    private async Task<Session> FindSession(User user)
    {
        Session session = Sessions.Find(x => x.User.TelegramClientId == user.TelegramClientId);
        if (session is not null)
            return session; 
        session = new Session()
        {
            User = user,
            Action ="LoginOrRegister",
            Controller = "Home"
        };
        return session;
    }
}