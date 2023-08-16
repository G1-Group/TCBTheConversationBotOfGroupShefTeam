
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCB.Aplication.Domain;

[Table("anonym_chat")]
public class AnonymChat:ModelBase
{
    [Column("create_time")]
    public DateTime Create_Time { get; set; }

    [Column("client_chat_id_first")]
    public long ClientChatIdFirst { get; set; }
    
    [NotMapped] 
    public Client ClientChatFirst { get; set; }
    
    [Column("client_chat_id_last")]
    public long ClientChatIdLast { get; set; }
    
    [NotMapped] 
    public Client ClientChatLast { get; set; }

    [Column("anonym_chat_status")]
    public AnonymChatStatus Status { get; set; }
    
    [NotMapped]
    public List<Message> Messages { get; set; }
    
}