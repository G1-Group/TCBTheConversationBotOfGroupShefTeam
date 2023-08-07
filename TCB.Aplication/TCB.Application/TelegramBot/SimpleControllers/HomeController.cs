using TCB.Aplication.Infrastructure.Service;
using TCB.Aplication.Services;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace TCB.Aplication.TelegramBot.Managers;

public class HomeController : ControllerBase
{
    private readonly UserDataService _userDataService;
    private readonly BoardCreateController _boardCreateCintroller;
    private readonly BoardListAllBoard _boardListAllBoard;
    private readonly LoginController _loginController;
    private readonly RegisterController _registerController;


    public HomeController(ITelegramBotClient botClient,
        UserDataService userDataService,
        LoginController loginController,
        ControllerManager controllerManager
    ) : base(botClient, controllerManager)
    {
        _userDataService = userDataService;
        _loginController = loginController;
    }

    public override bool HandleAction(ControllerContext context)
    {

        switch (context.Session.Action)
        {
            case nameof(this.Start):
            {
                this.Start(context).Wait();
                return true;
            }
            case "BoardListAllBorad":
            {
                _boardListAllBoard.HandleAction(context);
                return true;
            }
            case "BoardCreate":
            {
                _boardCreateCintroller.HandleAction(context);
                return true;
            }
            
        }

        return false;
    }

    public override bool HandleUpdate(ControllerContext context)
    {
        if (context.Update.Type != UpdateType.Message
            || context.Update.Message?.Type != MessageType.Text)
            return false;
        var message = context.Update.Message;

        switch (message.Text)
        {
            case "/login":
            {
                context.Session.Controller = nameof(LoginController);
                context.Session.Action = nameof(LoginController.LoginStepStart);

                return false;
            }
            case "/start":
            {
                context.Session.Action = nameof(HomeController.Start);
                return true;
            }
        }

        return false;
    }
    


    public async Task Login(ControllerContext context)
    {
        context.Session.Controller = nameof(LoginController);
        context.Session.Action = nameof(LoginController.LoginStepStart);
        
        this._loginController.HandleAction(context);
    }

    // public async Task Home(ControllerContext context)
    // {
    //     switch (context.Session.Action)
    //     {
    //         case "LoginOrRegister":
    //         {
    //             await SendMessage(context, "Login >> /login\nRegister >> /register");
    //             return;
    //         }
    //         default:
    //             await Start(context);
    //             break;
    //     }
    //
    //
    //     if (context.Update.Message.Type != MessageType.Text)
    //     {
    //         Start(context);
    //         return;
    //     }
    //
    //     if (context.Update.Message.Text == "/CreateBoard")
    //     {
    //         context.Session.Controller = "BoardCreate";
    //         _boardCreateCintroller.HandleAction(context);
    //         return;
    //     }
    //
    //     if (context.Update.Message.Text == "/ListAllBoard")
    //     {
    //         context.Session.Controller = "BoardListAllBorad";
    //         _boardListAllBoard.HandleAction(context);
    //         return;
    //     }
    //
    //     Start(context);
    // }

    public async Task Start(ControllerContext context)
    {
        await SendMessage(context, "Create Board >> /CreateBoard\nListAllBoard >> /ListAllBoard");
    }
}