using TCB.Aplication.Domain;
using TCB.Aplication.Infrastructure.Service;
using TCB.Aplication.Services;
using Telegram.Bot;
using MessageType = Telegram.Bot.Types.Enums.MessageType;

namespace TCB.Aplication.TelegramBot.Managers;

public class LoginController:ControllerBase
{
    private readonly AuthService _authService;
    private readonly UserDataService _userDataService;

    public LoginController(ITelegramBotClient botClient,AuthService authService , UserDataService userDataService) : base(botClient)
    {
        _authService = authService;
        _userDataService = userDataService;
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
                SendMessage(context, "/PhoneNumber or /GoBack");
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
        if (context.Update.Message.Type != MessageType.Text)
        {
            await SendMessage(context, "Write Text");
            return;
        }

        User user =await _userDataService.FindByPhoneNumber(context.Session.User.PhoneNumber);
        if (user is null)
        {
            SendMessage(context, "User not fund");
            return;
        }

        if (user.Password != context.Update.Message.Text)
        {
            SendMessage(context, "password xato");
            return;
        }

        SendMessage(context, "Successfully");
        context.Session.Controller = "HomeController";
        context.Session.Action = null;
    }


    public async Task PhoneNumber(ControllerContext context)
    {
        if (context.Update.Message.Type != MessageType.Contact)
        {
            SendMessage(context, "");
            context.Session.Action = "Start";
            return;
        } 
        if(_userDataService.FindByPhoneNumber(context.Update.Message.Contact.PhoneNumber) is null)
        {
            SendMessage(context, "Phone Number not found");
            context.Session.Action = "GoBack";
            return;
        }

        context.Session.User.PhoneNumber = context.Update.Message.Contact.PhoneNumber;
        
        SendMessage(context, "Enter your Password");
        context.Session.Action = "Password";
    }

    public async Task Start(ControllerContext context)
    {

        if (context.Update.Message.Text == "/PhoneNumber")
        {
            await SendMessage(context, "Enter your Phone Number?");
            context.Session.Action = "PhoneNumber";
        }

        if (context.Update.Message.Text == "/GoBack")
        {
            context.Session.Action = "GoBack";
        }
        
    }
}



