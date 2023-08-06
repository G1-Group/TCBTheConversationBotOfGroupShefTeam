using Telegram.Bot;

namespace TCB.Aplication.TelegramBot.Managers;

public class RegisterController : ControllerBase
{
    

    public override void HandleAction(ControllerContext context)
    {
        
    }

    public RegisterController(ITelegramBotClient botClient) : base(botClient)
    {
    }
}