
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

namespace TCB.Aplication.TelegramBot;

public class TelegramBotStartService
{
    public  string botToken = "6612151166:AAG65IbZu6q0K_RXx_8Vkdczm922RQpuCao";

    private TelegramBotClient _telegramBotClient;
    public TelegramBotStartService()
    {
        this._telegramBotClient = new TelegramBotClient(botToken);
    }



    public async Task StartMenu()
    {
        this._telegramBotClient.StartReceiving(
            (botClient, update, cancellationToken) =>
            {
                botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "Hello",
                    parseMode: ParseMode.Html
                );
                
                
                

                
            }, (botClient, exception, cancellationToken) =>
            {

            }, new ReceiverOptions()
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            }
        );
    }
    
    
}