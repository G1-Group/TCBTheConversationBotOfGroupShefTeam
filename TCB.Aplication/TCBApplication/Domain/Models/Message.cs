using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCB.Aplication.Domain;

[Table("messages")]
public class Message : ModelBase
{
    [Column("content")]
    public Telegram.Bot.Types.Message Content { get; set; }
    
    [Column("from_id")]
    public long FromId { get; set; }
    
    [NotMapped] 
    public Client Client { get; set; }
  
    
    [Column("time")]
    public DateTime Time { get; set; }
    
    [Column("board_id")]
    public long? BoardId { get; set; }
    
    [NotMapped] 
    public Board  Board { get; set; }
    
    [Column("conversation_id")]
    public long? ConversationId { get; set; }
    
    [NotMapped]
    public AnonymChat? Conversation { get; set; }
    
    [Column("message_type")]
    public MessageType MessageType { get; set; }

    [Column ("message_status")]
    public MessageStatus messageStatus { get; set; }
    
}