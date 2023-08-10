using TCB.Aplication.TelegramBot.Context.Extension;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace TCB.Aplication.TelegramBot.Managers;

public abstract class ControllerBase
{
    public readonly ControllerManager _controllerManager;


    public ControllerBase(
        ControllerManager controllerManager)
    {
        _controllerManager = controllerManager;
    }
   

    protected abstract Task HandleAction(ControllerContext context);
    protected abstract Task<Task> HandleUpdate(ControllerContext context);

    public async Task Handle(ControllerContext context)
    {
        await this.HandleUpdate(context);
        await this.HandleAction(context);
    }
    
    
    
    
}