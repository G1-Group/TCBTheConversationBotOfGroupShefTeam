using Telegram.Bot;

namespace TCB.Aplication.TelegramBot.Managers;

public abstract class ControllerBase
{
    protected readonly ITelegramBotClient _botClient;

    public ControllerBase(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }
    public abstract void HandleAction(ControllerContext context);
}