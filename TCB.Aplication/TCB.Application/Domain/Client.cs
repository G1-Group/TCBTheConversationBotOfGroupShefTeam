using System.ComponentModel;

namespace TCB.Aplication.Domain;

public class Client : ModelBase
{
    [Description("user_id")]
    public long UserId { get; set; }
    [Description("chat_id")]
    public long TelegramChatId { get; set; }
    [Description("nick_name")]
    public string NickName { get; set; }
    [Description("is_premium")]
    public bool IsPremium { get; set; }
    [Description("status")]
    public ClientStatus Status { get; set; }
    [Description("client_in_anonymChat")]
    public bool ClientInAnonymChat { get; set; } = false;
}