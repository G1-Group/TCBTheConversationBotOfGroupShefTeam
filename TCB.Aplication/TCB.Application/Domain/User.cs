using System.ComponentModel;

namespace TCB.Aplication.Domain;

public class User : ModelBase
{
    [Description("client_id")]
    public long TelegramClientId { get; set; }
    [Description("password")]
    public string Password { get; set; }
    [Description("phone_number")]
    public string PhoneNumber { get; set; }
    
    
}