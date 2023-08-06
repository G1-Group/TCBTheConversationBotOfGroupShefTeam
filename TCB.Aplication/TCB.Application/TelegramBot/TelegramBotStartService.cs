
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TCB.Aplication.TelegramBot;

public class TelegramBotStartService
{

    private TelegramBotClient _telegramBotClient;
    
    public TelegramBotStartService()
    {
         string botToken = "6612151166:AAG65IbZu6q0K_RXx_8Vkdczm922RQpuCao";
        this._telegramBotClient = new TelegramBotClient(botToken);
    }



    public async Task Start()
    {
        await StartReceiver();
    }
    
    
    private async Task StartReceiver()
    {
        var cancellationToken = new CancellationToken();
        var options = new ReceiverOptions();
        await _telegramBotClient.ReceiveAsync(OnMessage, ErrorMessage, options, cancellationToken);
    }
    
    private async Task OnMessage(ITelegramBotClient telegramBotClient, Update update, CancellationToken cancellationToken)
    {
       
    }
    
    private async Task ErrorMessage(ITelegramBotClient telegramBotClient, Exception exception, CancellationToken cancellationToken)
    {
    }
    
    
}