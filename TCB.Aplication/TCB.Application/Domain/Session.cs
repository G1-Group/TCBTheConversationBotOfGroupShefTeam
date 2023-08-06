using TCB.Aplication.Domain;

namespace TCB.Aplication.TelegramBot.Managers;

public class Session
{
    public long Id { get; set; }
    public User User { get; set; }
    public string Action { get; set; }
    public string Controller { get; set; }
}