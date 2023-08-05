using Telegram.Bot;

namespace TCB.Aplication.TelegramBot.Managers;

public abstract class ControllerBaseHandler
{
    protected readonly ITelegramBotClient _botClient;

    public ControllerBaseHandler(ITelegramBotClient botClient)
    {
        this._botClient = botClient;
    }
    public abstract void ClientHandleAction(ControllerContext context);
}