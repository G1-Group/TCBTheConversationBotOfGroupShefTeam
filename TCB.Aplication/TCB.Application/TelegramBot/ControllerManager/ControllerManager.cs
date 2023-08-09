using TCB.Aplication.Infrastructure.Service;
using TCB.Aplication.Services;
using Telegram.Bot;

namespace TCB.Aplication.TelegramBot.Managers;

public class ControllerManager
{
    public BoardController _boardController;
    public LoginController _loginController;
    public RegisterController _registerController;
    public HomeController _homeController;

    public ControllerManager(TelegramBotClient botClient, AuthService authService,
        BoardService boardService)
    {
        _loginController = new LoginController(botClient,authService,this);
        _boardController = new BoardController(botClient, boardService, this);
        _registerController = new RegisterController(botClient, authService, this );
        _homeController = new HomeController(botClient, this);
    }

    public ControllerBase GetControllerBySessionData(Session session)
    {
        //will check controllers by session.Conrtoller and return founded;
        switch (session.Controller)
        {
            case nameof(HomeController):
                return this._homeController;
            case nameof(LoginController):
                return this._loginController;
            case nameof(RegisterController):
                return this._registerController;
            case nameof(BoardController):
                return this._boardController;
            
        }
        
        return this.DefaultController;
    }
    public ControllerBase DefaultController => this._homeController;

    
}