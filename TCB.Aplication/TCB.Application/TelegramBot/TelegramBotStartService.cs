
using TCB.Aplication.Infrastructure.Service;
using TCB.Aplication.Services;
using TCB.Aplication.TelegramBot.Managers;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TCB.Aplication.TelegramBot;

public class TelegramBotStartService
{

    private TelegramBotClient _telegramBotClient;
    private readonly HandleUser _handleUser;

    public TelegramBotStartService(HandleUser handleUser)
    {
        _handleUser = handleUser;
        string botToken = "6271788643:AAE1cjCIemAYlNnVlp6YxczwldYuVj8dGQE";
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
        _handleUser.Handle(update);
    }
    
    private async Task ErrorMessage(ITelegramBotClient telegramBotClient, Exception exception, CancellationToken cancellationToken)
    {
    }
    
    
}