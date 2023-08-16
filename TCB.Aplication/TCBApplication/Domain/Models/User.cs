using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCB.Aplication.Domain;

[Table("users")]
public class User : ModelBase
{
    
    [Column("telegram_chat_id")]
    public long TelegramChatId { get; set; }
    [Column("password")]
    public string Password { get; set; }
    [Column("phone_number")]
    public string PhoneNumber { get; set; }
    
    [NotMapped] 
    public Client? Client { get; set; }
}