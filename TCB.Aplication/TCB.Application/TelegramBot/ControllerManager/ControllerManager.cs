using TCB.Aplication.Infrastructure.Service;
using Telegram.Bot;

namespace TCB.Aplication.TelegramBot.Managers;

public class ControllerManager
{
    public BoardController _boardController;
    public LoginController _loginController;
    public RegisterController _registerController;
    public HomeController _homeController;

    public ControllerManager(LoginController loginController, BoardController boardController, RegisterController registerController, HomeController homeController)
    {
        _loginController = loginController;
        _boardController = boardController;
        _registerController = registerController;
        _homeController = homeController;
    }

    public ControllerBase GetControllerBySessionData(Session session)
    {
        //will check controllers by session.Conrtoller and return founded;
        return null;
    }
    
    
}