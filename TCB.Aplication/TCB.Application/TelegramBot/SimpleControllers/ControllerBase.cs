using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace TCB.Aplication.TelegramBot.Managers;

public abstract class ControllerBase
{
    protected readonly ITelegramBotClient _botClient;

    public ControllerBase(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }
    public abstract void HandleAction(ControllerContext context);



    public async Task SendMessage(ControllerContext context , string text)
    {
        _botClient.SendTextMessageAsync(
            chatId: context.Update.Message.Chat.Id,
            parseMode: ParseMode.Html,
            text: text
        );
    }
}