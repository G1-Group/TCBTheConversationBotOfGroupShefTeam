namespace TCB.Aplication.Domain;

public class Client : ModelBase
{
    public long UserId { get; set; }
    public long TelegramChatId { get; set; }
    public string NickName { get; set; }
    public bool IsPremium { get; set; }
    public ClientStatus Status { get; set; }
    public bool ClientInAnonymChat { get; set; }
}