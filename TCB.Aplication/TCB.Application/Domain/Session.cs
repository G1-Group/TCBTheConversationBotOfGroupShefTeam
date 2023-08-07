using TCB.Aplication.Domain;
using TCB.Aplication.Infrastructure.Service;

namespace TCB.Aplication.TelegramBot.Managers;

public class Session
{
    public long Id { get; set; }
    public User User { get; set; }
    public string Action { get; set; }
    public string Controller { get; set; }

    public Board board { get; set; }
    public AnonymChat anonym { get; set; }
}