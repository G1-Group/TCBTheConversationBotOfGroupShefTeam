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
    private readonly AuthService _authService;

    public RegisterController(ITelegramBotClient botClient , AuthService authService, ControllerManager controllerManager) : base(botClient, controllerManager)
    {
        _authService = authService;   
    }

    public override async Task<bool> HandleAction(ControllerContext context)
    {
        switch (context.Session.Action)
        {

            case nameof(RegisterStepFirst):
            {
                await RegisterStepFirst(context);
                return true;
            }
            case nameof(RegisterStepLast):
            {
                await RegisterStepLast(context);
                return true;
            }
            case nameof(RegisterStepThird):
            {
                await RegisterStepThird(context);
                return true;
            }
            default:
            {
                await RegisterStepStart(context);
                return true;
            }
        }
    }

    public override async Task<bool>HandleUpdate(ControllerContext context)
    {
        throw new NotImplementedException();
    }


    public async Task RegisterStepStart(ControllerContext context)
    {
        SendMessage(context, "Enter your Phone Number✍️");
        context.Session.Action = nameof(RegisterStepFirst);
    }

    public async Task RegisterStepFirst(ControllerContext context)
    {
        context.Session.RegisterSession.PhoneNumber = context.Update.Message?.Contact?.PhoneNumber;
        if (string.IsNullOrEmpty(context.Update.Message?.Contact?.PhoneNumber))
        {
            await SendMessage(context, "Place Enter Your Phone Number ");
            return;
        }

        await SendMessage(context,"Enter Your Password");
        context.Session.Action = nameof(RegisterStepLast);
    }

    public async Task RegisterStepLast(ControllerContext context)
    {
        context.Session.RegisterSession.Password = context.Update.Message?.Text;
        if (string.IsNullOrEmpty(context.Update.Message?.Text))
        {
            await SendMessage(context, "Place Enter Your Password");
            return;
        }
        User user = new User()
        {
            PhoneNumber = context.Session.RegisterSession.PhoneNumber,
            TelegramChatId = context.Update.Message.Chat.Id,
            Password = context.Session.RegisterSession.Password
        };

        await SendMessage(context, "Enter Your Nick Name");
        context.Session.Action = nameof(RegisterStepThird);
    }

    public async Task RegisterStepThird(ControllerContext context)
    {
        context.Session.RegisterSession.NickName = context.Update.Message?.Text;
        if (string.IsNullOrEmpty(context.Update.Message?.Text))
        {
            await SendMessage(context,"Place Enter Your NickName");
            return;
        }

        
        if (context.Session.RegisterSession.NickName != null)
        {
            var result=await _authService.Registration(context.Session.User, context.Session.RegisterSession.NickName);
            if (result is null)
            {
                await SendMessage(context, "the error is in the user base");
                await RegisterStepStart(context);
                return;
            }
            context.Session.User = result;
        }
        
        context.Session.Controller = nameof(LoginController);
        await SendMessage(context, "You are registered Successfully");
        context.Session.Action = null;
        await _controllerManager._loginController.Handle(context);
    }

}