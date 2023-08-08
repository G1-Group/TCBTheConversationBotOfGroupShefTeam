using System.ComponentModel;

namespace TCB.Aplication.Domain;

public class User : ModelBase
{
    [Description("chat_id")]
    public long TelegramChatId { get; set; }
    [Description("password")]
    public string Password { get; set; }
    [Description("phone_number")]
    public string PhoneNumber { get; set; }
}