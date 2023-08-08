
using System.ComponentModel;

namespace TCB.Aplication.Domain;

public class AnonymChat:ModelBase
{
    [Description("time")]
    public DateTime time { get; set; }
    
    [Description("client_chat_id_first")]
    public long ClientChatIdFirst { get; set; }
    
    [Description("client_chat_id_last")]
    public long ClientChatIdLast { get; set; }
    
    [Description("anonym_chat_status")]
    public AnonymChatStatus Status { get; set; }
}