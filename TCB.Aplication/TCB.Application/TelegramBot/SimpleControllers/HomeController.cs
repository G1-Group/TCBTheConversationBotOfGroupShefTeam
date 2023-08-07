using TCB.Aplication.Infrastructure.Service;
using TCB.Aplication.Services;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace TCB.Aplication.TelegramBot.Managers;

public class HomeController:ControllerBase
{
    private readonly BoardCreateController _boardCreateCintroller;
    private readonly BoardListAllBoard _boardListAllBoard;
    private readonly LoginController _loginController;
    private readonly RegisterController _registerController;


    public HomeController(ITelegramBotClient botClient,
        BoardCreateController boardCreateCintroller,
        BoardListAllBoard boardListAllBoard,
        LoginController loginController,
        RegisterController registerController,
        UserDataService userDataService) : base(botClient)
    {
        _boardCreateCintroller = boardCreateCintroller;
        _boardListAllBoard = boardListAllBoard;
        _loginController = loginController;
        _registerController = registerController;
    }

    public override void HandleAction(ControllerContext context)
    {
        switch (context.Session.Controller)
        {
            case "Login":
            {
                _loginController.HandleAction(context);
                break;
            }
            case "Register":
            {
                _registerController.HandleAction(context);
                break;
            }
            case "BoardListAllBorad":
            {
                _boardListAllBoard.HandleAction(context);
                break;
            }
            case "BoardCreate":
            {
                _boardCreateCintroller.HandleAction(context);
                break;
            }
            default:
            {
                Home(context);
                break;
            }
        }
    }

    public async Task Home(ControllerContext context)
    {
        switch (context.Session.Action)
        {
            case "LoginOrRegister":
            {
                SendMessage(context, "Login >> /login\nRegister >> /register");
                return;
            }
            default:
                break;
        }
        
        
        if (context.Update.Message.Type != MessageType.Text)
        {
            Start(context);
            return;
        }

        if (context.Update.Message.Text == "/CreateBoard")
        {
            context.Session.Controller = "BoardCreate";
            _boardCreateCintroller.HandleAction(context);
            return;
        }

        if (context.Update.Message.Text == "/ListAllBoard")
        {
            context.Session.Controller = "BoardListAllBorad";
            _boardListAllBoard.HandleAction(context);
            return;
        }

        Start(context);

    }
    public async Task Start(ControllerContext context)
    {
        SendMessage(context, "Create Board >> /CreateBoard\nListAllBoard >> /ListAllBoard");
    }
    
    
    
    
}