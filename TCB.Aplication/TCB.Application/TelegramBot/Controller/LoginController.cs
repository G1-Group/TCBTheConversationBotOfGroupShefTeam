using TCB.Aplication.Domain;
using TCB.Aplication.Infrastructure.Service;
using TCB.Aplication.Services;
using Telegram.Bot;
using MessageType = Telegram.Bot.Types.Enums.MessageType;

namespace TCB.Aplication.TelegramBot.Managers;

public class LoginController:ControllerBase
{
    private readonly UserDataService _userDataService;

    private string userLogin = null;
    private string userPassword = null;
    public LoginController(ITelegramBotClient botClient, UserDataService userDataService, ControllerManager controllerManager) : base(botClient, controllerManager)
    {
        _userDataService = userDataService;
    }

    public override async Task<bool> HandleAction(ControllerContext context)
    {
        switch (context.Session.Action)
        {
            case nameof(LoginStepStart):
            {
                LoginStepStart(context).Wait();
                return true;
            }
            case nameof(LoginStepFirst):
            {
                LoginStepFirst(context).Wait();
                return true;
            }
            case nameof(LoginStepTwo):
            {
                LoginStepTwo(context).Wait();
                return true;
            }
            // case "GoBack":
            // {
            //     GoBack(context);
            //     break;
            // }
            // case "Password":
            // {
            //     Password(context);
            //     break;
            // }
            // case "PhoneNumber":
            // {
            //     PhoneNumber(context);
            //     break;
            // }
            // default:
            // {
            //     SendMessage(context, "/PhoneNumber or /GoBack");
            //     Start(context);
            //     break;
            // }
        }

        return false;
    }

    public override async Task<bool> HandleUpdate(ControllerContext context)
    {
        return true;
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
            await SendMessage(context, "User not fund");
            return;
        }

        if (user.Password != context.Update.Message.Text)
        {
            await SendMessage(context, "password xato");
            return;
        }

        await SendMessage(context, "Successfully");
        context.Session.Controller = "HomeController";
        context.Session.Action = null;
    }


    public async Task PhoneNumber(ControllerContext context)
    {
        if (context.Update.Message.Type != MessageType.Contact)
        {
            await SendMessage(context, "");
            context.Session.Action = "Start";
            return;
        } 
        if(_userDataService.FindByPhoneNumber(context.Update.Message.Contact.PhoneNumber) is null)
        {
            await SendMessage(context, "Phone Number not found");
            context.Session.Action = "GoBack";
            return;
        }

        context.Session.User.PhoneNumber = context.Update.Message.Contact.PhoneNumber;
        
        await SendMessage(context, "Enter your Password");
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

    public async Task LoginStepStart(ControllerContext context)
    {
        await SendMessage(context, "Enter your Login: ");

        context.Session.Action = nameof(LoginStepFirst);
    }
    
    public async Task LoginStepFirst(ControllerContext context)
    {
        context.Session.UserLogin = context.Update.Message?.Text;
        
        if (string.IsNullOrEmpty(context.Session.UserLogin))
        {
            await SendMessage(context, "Wrong login: ");
            return;
        }
        await SendMessage(context, "Enter your password: ");
        context.Session.Action = nameof(LoginStepTwo);
    }

    public async Task LoginStepTwo(ControllerContext context)
    {
        context.Session.UserPassword = context.Update.Message?.Text;
        
        if (string.IsNullOrEmpty(context.Session.UserPassword))
        {
            await SendMessage(context, "Wrong password: ");
            return;
        }
        
        await SendMessage(context, $"Login: {context.Session.UserLogin}\nPassword: {context.Session.UserPassword}");

        context.Session.Controller = null;
        context.Session.Action = null;
    }
}



