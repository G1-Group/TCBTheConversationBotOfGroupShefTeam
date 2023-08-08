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
                await LoginStepStart(context);
                return true;
            }
            case nameof(LoginStepFirst):
            {
                await LoginStepFirst(context);
                return true;
            }
            case nameof(LoginStepLast):
            {
                await LoginStepLast(context);
                return true;
            }
          
        }

        return false;
    }

    public override async Task<bool> HandleUpdate(ControllerContext context)
    {
        if (context.Update.Message.Type != MessageType.Text)
            return false;
        switch (context.Update.Message.Text)
        {
            
            case "/Login":
            {
                await LoginStepStart(context);
                return true;
            }
           
            
        }

        return false;
    }

   
    

    public async Task LoginStepStart(ControllerContext context)
    {
        await SendMessage(context, "Enter your Login: ");

        context.Session.Action = nameof(LoginStepFirst);
    }
    
    public async Task LoginStepFirst(ControllerContext context)
    {
        if (context.Update.Message.Type != MessageType.Text)
        {
             await this.SendMessage(context, "Please send message ");
            await LoginStepStart(context);
            return;
        }
        
        context.Session.UserLogin = context.Update.Message.Text;
        
        if (string.IsNullOrEmpty(context.Session.UserLogin))
        {
            await SendMessage(context, "Wrong login: ");
            return;
        }
        await SendMessage(context, "Enter your password: ");
        context.Session.Action = nameof(LoginStepLast);
    }

    public async Task LoginStepLast(ControllerContext context)
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



