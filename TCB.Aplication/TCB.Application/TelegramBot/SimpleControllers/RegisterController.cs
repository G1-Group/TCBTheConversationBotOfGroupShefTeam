using TCB.Aplication.Infrastructure.Service;
using TCB.Aplication.Services;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using User = TCB.Aplication.Domain.User;

namespace TCB.Aplication.TelegramBot.Managers;

public class RegisterController : ControllerBase
{
    private readonly UserDataService _userDataService;

    public RegisterController(ITelegramBotClient botClient , UserDataService userDataService) : base(botClient)
    {
        _userDataService = userDataService;
    }

    public override void HandleAction(ControllerContext context)
    {
        switch (context.Session.Action)
        {
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

    
    
    public async Task Start(ControllerContext context)
    {
        SendMessage(context, "Enter your Phone Number✍️");
        context.Session.Action = "PhoneNumber";
    }
    
    
    public async Task PhoneNumber(ControllerContext context)
    {
        if (context.Update.Message.Type != MessageType.Text)
        {
            SendMessage(context, "Enter your Phone Number✍️");
            return;
        }

        User user = await  _userDataService.FindByPhoneNumber(context.Update.Message.Text);
        if (user.PhoneNumber is not null)
        {
            SendMessage(context, "No such number exists\nor /GoBack");
            return;
        }

        context.Session.User = user;
       // _userDataService.CreateData(user.PhoneNumber)
        SendMessage(context, "Enter your Password✍️");
        context.Session.Action = "Password";
    }
    
    
    public async Task Password(ControllerContext context)
    {
        
        
        context.Session.Controller = "Login";
        context.Session.Action = null;
    }


    public async Task NickName(ControllerContext context)
    {
        if (context.Update.Message.Text == "/GoBack")
        {
            GoBack(context);
            return;
        }

        if (context.Update.Message.Type != MessageType.Text)
        {
            SendMessage(context, "Enter your NickName✍️");
        }
        
        
        context.Session.Action = "Password";
    }


    public async Task GoBack(ControllerContext context)
    {
        // ... Og'abek
    }


}