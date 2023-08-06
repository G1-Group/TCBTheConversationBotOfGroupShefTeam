using Telegram.Bot;
using Telegram.Bot.Types;

namespace TCB.Aplication.TelegramBot.Managers;

public class UpdateHandlers
{
    
    public List<DelegateUpdateHandler> DelegateUpdateHandlers ;
    
    public async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken arg)
    {
        
    }

    public UpdateHandlers()
    {
        this.DelegateUpdateHandlers = new List<DelegateUpdateHandler>();
    }

    private Task UpdateHandlerError(ITelegramBotClient botClient, Exception exception, CancellationToken arg)
    {
        throw new NotImplementedException();
    }

    public delegate Task DelegateUpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken token);
    
}