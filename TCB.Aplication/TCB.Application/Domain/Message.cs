using System.ComponentModel;

namespace TCB.Aplication.Domain;

public class Message : ModelBase
{
    [Description("text")]
    public string text { get; set; }
    
    [Description("from_id")]
    public long? FromId { get; set; }
    
    [Description("time")]
    public DateTime time { get; set; }
    
    [Description("board_id")]
    public long? BoardId { get; set; }
    
    [Description("anonym_chat_id")]
    
    public long? AnonymChatId { get; set; }
    
    [Description("status")]
    public MessageType status { get; set; }

    [Description ("message_status")]
    public MessageStatus messageStatus { get; set; }
    
}