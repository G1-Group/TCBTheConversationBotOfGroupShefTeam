using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace TCB.Aplication.TelegramBot.Managers;

public abstract class ControllerBase
{
    protected readonly ITelegramBotClient _botClient;
    private readonly ControllerManager _controllerManager;

    public ControllerBase(ITelegramBotClient botClient, ControllerManager controllerManager)
    {
        _botClient = botClient;
        _controllerManager = controllerManager;
    }
    public abstract Task HandleAction(ControllerContext context);

    public abstract Task<bool> HandleUpdate(ControllerContext context);

    public virtual async Task Handle(ControllerContext context)
    {
        var updateHandled = this.HandleUpdate(context);

        if (!await updateHandled)
        {
            var controllerBase = _controllerManager.GetControllerBySessionData(context.Session);
            controllerBase.Handle(context);
        }
        else 
            this.HandleAction(context);
    }
    
    public async Task SendMessage(ControllerContext context , string text)
    {
        _botClient.SendTextMessageAsync(
            chatId: context.Update.Message.Chat.Id,
            parseMode: ParseMode.Html,
            text: text
        );
    }

    public async Task Start(ControllerContext context)
    {
        
    }
    
}