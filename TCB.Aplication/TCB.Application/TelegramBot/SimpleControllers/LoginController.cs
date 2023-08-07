using TCB.Aplication.Services;
using Telegram.Bot;

namespace TCB.Aplication.TelegramBot.Managers;

public class LoginController:ControllerBase
{
    private readonly AuthService _authService;

    public LoginController(ITelegramBotClient botClient,AuthService authService) : base(botClient)
    {
        _authService = authService;
    }

    public override void HandleAction(ControllerContext context)
    {
        switch (context.Session.Action)
        {
            case "GoBack":
            {
                GoBack(context);
                break;
            }
            case "Password":
            {
                Password(context);
                break;
            }
            case "PhoneNumber":
            {
                PhoneNumber(context);
                break;
            }
            default:
            {
                Start(context);
                break;
            }
        }
    }

    public async Task GoBack(ControllerContext context)
    {
        // ... Og'abek
    }


    public async Task Password(ControllerContext context)
    {
        // ... Azimjon zem
        context.Session.Controller = "HomeController";
        context.Session.Action = null;
    }


    public async Task PhoneNumber(ControllerContext context)
    {
        // ... Azimjon zem
        context.Session.Action = "Password";
    }

    public async Task Start(ControllerContext context)
    {
        // ... Azimjon zem
        context.Session.Action = "PhoneNumber";
    }



}