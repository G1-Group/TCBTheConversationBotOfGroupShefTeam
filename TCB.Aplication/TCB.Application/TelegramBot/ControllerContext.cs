using Telegram.Bot.Types;

namespace TCB.Aplication.TelegramBot.Managers;

public class ControllerContext
{
    public Update? Update { get; set; }
    public Session? Session { get; set; }
    
}