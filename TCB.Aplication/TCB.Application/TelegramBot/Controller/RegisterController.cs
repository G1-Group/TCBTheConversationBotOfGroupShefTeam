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

    public RegisterController(ITelegramBotClient botClient , UserDataService userDataService, ControllerManager controllerManager) : base(botClient, controllerManager)
    {
        _userDataService = userDataService;
    }

    public override async Task<bool> HandleAction(ControllerContext context)
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

        return true;
    }

    public override async Task<bool>HandleUpdate(ControllerContext context)
    {
        throw new NotImplementedException();
    }


    public async Task Start(ControllerContext context)
    {
        SendMessage(context, "Enter your Phone Number✍️");
        context.Session.Action = "PhoneNumber";
    }
    
    
    public async Task PhoneNumber(ControllerContext context)
    {
        if (context.Update.Message.Type != MessageType.Contact)
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

        context.Session.User = new User()
        {
            PhoneNumber = context.Update.Message.Text,
            TelegramChatId = context.Update.Message.Chat.Id
        };
        SendMessage(context, "Enter your Password✍️");
        context.Session.Action = "Password";
    }
    
    
    public async Task Password(ControllerContext context)
    {
        
        if (context.Update.Message.Type != MessageType.Text)
        {
            SendMessage(context, "Enter your Password✍️");
            return;
        }
        if (context.Update.Message.Text == "/GoBack")
        {
            await GoBack(context);
            return;
        }

        User user =await _userDataService.FindByChatId(context.Update.Message.Chat.Id);

        if (user is  null)
        {
            SendMessage(context, "User No found");
            Start(context);
            return;
        }

        user.Password = context.Update.Message.Text;
        context.Session.User = user;

        await _userDataService.CreateData(user);
        SendMessage(context, "Successfully");
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
        SendMessage(context, "Type a character");
        context.Session.Controller = "Register";
        context.Session.Action = null;
    }


}