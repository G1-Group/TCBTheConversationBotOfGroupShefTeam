using TCB.Aplication.Infrastructure.Service;
using TCB.Aplication.Services;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace TCB.Aplication.TelegramBot.Managers;

public class HomeController : ControllerBase
{
    public HomeController(ITelegramBotClient botClient, ControllerManager controllerManager) : base(botClient, controllerManager)
    {
    }

    public override async Task HandleAction(ControllerContext context)
    {
        throw new NotImplementedException();
    }

    public override async Task<bool> HandleUpdate(ControllerContext context)
    {
        throw new NotImplementedException();
    }
}