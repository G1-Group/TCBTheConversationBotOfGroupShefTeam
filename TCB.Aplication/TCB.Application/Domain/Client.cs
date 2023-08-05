using System.ComponentModel;

namespace TCB.Aplication.Domain;

public class Client : ModelBase
{
    [Description("user_id")]
    public long UserId { get; set; }
    [Description("chat_id")]
    public long TelegramChatId { get; set; }
    [Description("nickName")]
    public string NickName { get; set; }
    [Description("isPremium")]
    public bool IsPremium { get; set; }
    [Description("status")]
    public ClientStatus Status { get; set; }
    [Description("clientInAnonymChat")]
    public bool ClientInAnonymChat { get; set; } = false;
}