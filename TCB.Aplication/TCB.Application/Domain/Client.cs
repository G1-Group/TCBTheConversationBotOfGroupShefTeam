namespace TCB.Aplication.Domain;

public class Client
{
    public long ClientId { get; set; }
    public long UserId { get; set; }
    public long TelegramChatId { get; set; }
    public string NickName { get; set; }
    public bool IsPremium { get; set; }
    public ClientStatus Type { get; set; }
}