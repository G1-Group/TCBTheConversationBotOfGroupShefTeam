using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TCB.Aplication.TelegramBot.Managers;

public abstract class ControllerBase
{
    protected readonly ITelegramBotClient _botClient;

    public ControllerBase(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }
    public abstract void HandleAction(ControllerContext context);



    public async Task SendInlineButtonMessage(ControllerContext context, string text, string inlineButtonTexts)
    {
        Message message = await _botClient.SendTextMessageAsync(
            chatId: context.Update.Message.Chat.Id,
            text: text,
            parseMode: ParseMode.Html,
            replyMarkup: new InlineKeyboardMarkup(
                InlineKeyboardButton.WithSwitchInlineQuery(
                    text: inlineButtonTexts
                ))
        );
    }

    public async Task SendMessage(ControllerContext context , string text)
    {
        _botClient.SendTextMessageAsync(
            chatId: context.Update.Message.Chat.Id,
            parseMode: ParseMode.Html,
            text: text
        );
    }
}