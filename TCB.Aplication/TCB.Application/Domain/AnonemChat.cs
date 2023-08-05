
using System.ComponentModel;

namespace TCB.Aplication.Domain;

public class AnonymChat:ModelBase
{
    [Description("create_time")]
    public DateTime CreateData { get; set; }
    
    [Description("from_id")]
    public long ClientFromId { get; set; }
    
    [Description("client_id")]
    public long ConnectClientId { get; set; }
    
    [Description("anonymChatStatus")]
    public AnonymChatStatus Status { get; set; }
}