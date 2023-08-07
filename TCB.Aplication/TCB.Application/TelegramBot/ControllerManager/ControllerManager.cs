using TCB.Aplication.Infrastructure.Service;
using Telegram.Bot;

namespace TCB.Aplication.TelegramBot.Managers;

public class ControllerManager
{
    public readonly HomeController _homeController;
    public readonly LoginController _loginController;
    public ControllerManager(ITelegramBotClient client, UserDataService userDataService)
    {
        this._loginController = new LoginController(client, userDataService, this);
        this._homeController = new HomeController(client, userDataService, _loginController, this);
    }

    public ControllerBase GetControllerBySessionData(Session session)
    {
        //will check controllers by session.Conrtoller and return founded;

        switch (session.Controller)
        {
            case nameof(LoginController):
                return this._loginController;
            
            default:
                return this._homeController;
        }

        return null;
    }
}