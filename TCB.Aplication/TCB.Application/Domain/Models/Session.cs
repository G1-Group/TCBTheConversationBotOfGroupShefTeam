using TCB.Aplication.Domain;
using TCB.Aplication.Infrastructure.Service;

namespace TCB.Aplication.TelegramBot.Managers;

public class Session
{
    public long Id { get; set; }
    public User  User { get; set; }
    public string Action { get; set; }
    public string Controller { get; set; }
    public long TelegramChatId { get; set; }
    public long ClientId { get; set; }
    
    public LoginSession LoginSession { get; set; }
    public RegisterSession RegisterSession { get; set; }
    public BoardSession BoardSession { get; set; }

    public Session()
    {
        this.LoginSession = new LoginSession();
        this.RegisterSession = new RegisterSession();
        this.BoardSession = new BoardSession();
    }
}
