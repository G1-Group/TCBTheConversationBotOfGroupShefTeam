using Telegram.Bot;

namespace TCB.Aplication.TelegramBot.Managers;

public class HomeController:ControllerBase
{
    public HomeController(ITelegramBotClient botClient) : base(botClient)
    {
    }

    public override void HandleAction(ControllerContext context)
    {
        
    }
}