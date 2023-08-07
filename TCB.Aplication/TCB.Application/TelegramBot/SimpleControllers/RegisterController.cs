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
    public RegisterController(ITelegramBotClient botClient) : base(botClient)
    {
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
            case "NickName":
            {
                NickName(context);
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

    public async Task Password(ControllerContext context)
    {
        // ... Malika opa 
        context.Session.Controller = "Login";
        context.Session.Action = null;
    }

    public async Task PhoneNumber(ControllerContext context)
    {
        // ... Malika opa
        context.Session.Action = "NickName";
    }

    public async Task NickName(ControllerContext context)
    {
        // ... Malika opa
        context.Session.Action = "Password";
    }

    public async Task Start(ControllerContext context)
    {
        // ... Malika opa
        context.Session.Action = "PhoneNumber";
    }

    public async Task GoBack(ControllerContext context)
    {
        // ... Og'abek
    }


}