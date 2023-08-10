using TCB.Aplication.TelegramBot.Context.Extension;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace TCB.Aplication.TelegramBot.Managers;

public abstract class ControllerBase
{
    protected readonly ITelegramBotClient _botClient;
    public readonly ControllerManager _controllerManager;


    public ControllerBase(ITelegramBotClient botClient , 
        ControllerManager controllerManager)
    {
        _botClient = botClient;
        _controllerManager = controllerManager;
    }
   

    protected abstract Task HandleAction(ControllerContext context);
    protected abstract Task HandleUpdate(ControllerContext context);

    public async Task Handle(ControllerContext context)
    {
        await this.HandleUpdate(context);
        await this.HandleAction(context);
    }
    
    public async Task SendMessage(ControllerContext context , string text)
    {
        await _botClient.SendTextMessageAsync(
            chatId: context.Update.Message.Chat.Id,
            parseMode: ParseMode.Html,
            text: text
        );
    }

    
    
}