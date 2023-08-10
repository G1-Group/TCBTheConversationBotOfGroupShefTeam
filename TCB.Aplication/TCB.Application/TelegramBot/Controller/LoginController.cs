using TCB.Aplication.Domain;
using TCB.Aplication.Infrastructure.Service;
using TCB.Aplication.Services;
using Telegram.Bot;
using MessageType = Telegram.Bot.Types.Enums.MessageType;

namespace TCB.Aplication.TelegramBot.Managers;

public class LoginController:ControllerBase
{
    private readonly AuthService _authService;

    private string userLogin = null;
    private string userPassword = null;
    public LoginController(ITelegramBotClient botClient,AuthService authService, ControllerManager controllerManager) : base(controllerManager)
    {
        _authService = authService;
    }

    protected override async Task<bool> HandleAction(ControllerContext context)
    {
        switch (context.Session.Action)
        {
            case nameof(LoginStepFirst):
            {
                LoginStepFirst(context).Wait();
                return true;
            }
            case nameof(LoginStepLast):
            {
                LoginStepLast(context).Wait();
                return true;
            }
            default:
            {
                LoginStepStart(context).Wait();
                return true;
            }
        }

        return false;
    }

    protected override async Task<Task> HandleUpdate(ControllerContext context)
    {
        return Task.CompletedTask;
    }

   


    public async Task LoginStepStart(ControllerContext context)
    {
        await SendMessage(context, "Enter your Phone Number: ");

        context.Session.Action = nameof(LoginStepFirst);
        await LoginStepFirst(context);
    }
    
    public async Task LoginStepFirst(ControllerContext context)
    {
        context.Session.LoginSession.PhoneNumber = context.Update.Message?.Contact.PhoneNumber;
        
        if (string.IsNullOrEmpty(context.Session.LoginSession.Password))
        {
            await SendMessage(context, "Wrong login: ");
            return;
        }
        await SendMessage(context, "Enter your password: ");
        context.Session.Action = nameof(LoginStepLast);
        await LoginStepLast(context);
    }

    private async Task SendMessage(ControllerContext context, string wrongLogin)
    {
        throw new NotImplementedException();
    }

    public async Task LoginStepLast(ControllerContext context)
    {
        context.Session.LoginSession.Password = context.Update.Message?.Text;
        
        if (string.IsNullOrEmpty(context.Session.LoginSession.Password))
        {
            await SendMessage(context, "Wrong password: ");
            return;
        }

        Client client = await _authService.Login(context.Session.LoginSession.PhoneNumber, context.Session.LoginSession.Password);
        if (client is null)
        {
            await SendMessage(context, "not found !");
            await LoginStepStart(context);
            return;
        }
        
        await SendMessage(context, $"Login: {context.Session.LoginSession.PhoneNumber}\nPassword: {context.Session.LoginSession.Password}");
        
        context.Session.ClientId = client.Id;
        context.Session.Controller = nameof(HomeController);
        context.Session.Action = null;
        await _controllerManager._homeController.Handle(context);
    }
}



